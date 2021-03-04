using Microsoft.EntityFrameworkCore;
using Quiz.Server.Data;
using Quiz.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Server.Services
{
    public class QuizService : IQuizService
    {
        private readonly DataContext db;

        public QuizService(DataContext db)
        {
            this.db = db;
        }

        public QuizCheckResponse Check(int quizId, ICollection<UserSelection> selections)
        {
            var correctAnswers = this.db.QuestionQuizzes
                .Where(qq => qq.QuizId == quizId)
                .Select(qq => new UserSelection
                {
                    QuestionId = qq.QuestionId,
                    AnswerId = qq.Question.Answers.FirstOrDefault(a => a.IsCorrect).Id
                })
                .ToHashSet();

            var response = new QuizCheckResponse
            {
                Correct = 0,
                Wrong = 0
            };

            foreach (var selection in selections)
            {
                if (correctAnswers.Any(c => c.QuestionId == selection.QuestionId && c.AnswerId == selection.AnswerId))
                {
                    response.Correct++;
                }
                else
                {
                    response.Wrong++;
                }
            }

            this.AddToHistory(quizId, selections);
            return response;
        }

        public async Task<int> CreateAsync(string userId)
        {
            var rng = new Random();
            
            var quiz = new Data.Quiz { Finished = DateTime.Now, UserId = userId };
            await this.db.Quizzes.AddAsync(quiz);
            var questions = this.db.Questions.ToArray();
            var questionsForCurrentQuiz = new List<Question>();

            for (int i = 0; i < 5; i++)
            {
                var question = questions[rng.Next(questions.Count())];
                while (questionsForCurrentQuiz.Any(q => q.Id == question.Id))
                {
                    question = questions[rng.Next(questions.Count())];
                }

                questionsForCurrentQuiz.Add(question);
                await this.db.QuestionQuizzes.AddAsync(new QuestionQuiz
                {
                    Question = question,
                    Quiz = quiz
                });
            }

            await this.db.SaveChangesAsync();
            return quiz.Id;
        }

        public async Task<QuizViewModel> GetAsync(int quizId)
        {
            var questions = this.db.QuestionQuizzes
                .Where(qq => qq.QuizId == quizId)
                .Select(qq => new QuestionViewModel
                {
                    Id = qq.Question.Id,
                    Content = qq.Question.Content,
                    CategoryId = qq.Question.CategoryId,
                    Answers = qq.Question.Answers.Select(a => new AnswerViewModel
                    {
                        Id = a.Id,
                        Content = a.Content
                    }).ToList()
                }).ToList();

            return await this.db.Quizzes
                .Select(q => new QuizViewModel
                {
                    Id = q.Id,
                    UserId = q.UserId,
                    Questions = questions
                }).FirstOrDefaultAsync(q => q.Id == quizId);
        }

        public IList<CategoryViewModel> GetCategories()
        {
            return this.db.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        }

        public async Task<IList<AnswerHistoryViewModel>> GetOnlyThree(string userId)
        {
            var user = await this.db.Users
                .Select(u => new User 
                {
                    Id = u.Id,
                    Quizzes = u.Quizzes
                })
                .FirstOrDefaultAsync(u => u.Id == userId);
            var userQuizzes = user.Quizzes;
            if (userQuizzes.Count < 3)
            {
                return null;
            }

            var result = new List<AnswerHistoryViewModel>();

            foreach (var quiz in userQuizzes.OrderByDescending(q => q.Finished).Take(3))
            {
                var quizQuestions = this.db.QuestionQuizzes
                   .Where(qq => qq.QuizId == quiz.Id)
                   .Select(qq => new QuestionSelectModel
                   {
                       Id = qq.QuestionId,
                       CategoryId = qq.Question.CategoryId,
                       Answers = qq.Question.Answers.Select(a => new AnswerSelectModel
                       {
                           Id = a.Id,
                           IsCorrect = a.IsCorrect
                       })
                   })
                   .ToList();

                var historyQuiz = await this.db.Histories
                    .Select(h => new History 
                    {
                        QuizId = h.QuizId,
                        Selections = h.Selections.Select(s => new Selection 
                        {
                            QuestionId = s.QuestionId,
                            AnswerId = s.AnswerId,
                        })
                        .ToList()
                    })
                    .FirstOrDefaultAsync(h => h.QuizId == quiz.Id);


                foreach (var selection in historyQuiz.Selections)
                {
                    var question = quizQuestions
                        .FirstOrDefault(q =>
                            q.Answers.FirstOrDefault(a => a.Id == selection.AnswerId) != null
                            && q.Id == selection.QuestionId);

                    if (question != null) //check
                    {
                        var neededAnswer = question.Answers.FirstOrDefault(a => a.Id == selection.AnswerId);

                        result.Add(new AnswerHistoryViewModel
                        {
                            IsCorrect = neededAnswer.IsCorrect,
                            CategoryId = question.CategoryId
                        });
                    }
                }
            }

            return result;
        }

        private void AddToHistory(int quizId, ICollection<UserSelection> selections)
        {
            var history = new History { QuizId = quizId };
            this.db.Histories.Add(history);

            foreach (var selection in selections)
            {
                this.db.Selections.Add(new Selection
                {
                    History = history,
                    QuestionId = selection.QuestionId,
                    AnswerId = selection.AnswerId
                });
            }

            this.db.SaveChanges();
        }
    }
}
