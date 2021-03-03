using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Server.Data;
using Quiz.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly DataContext db;

        public QuizController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet("{quizId}")]
        public async Task<QuizViewModel> Get(int quizId)
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

        [HttpPost]
        public async Task<IActionResult> Create(string userId)
        {
            var rng = new Random();

            var quiz = new Data.Quiz { UserId = userId };
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
            return Created(nameof(this.Create), quiz.Id);
        }

        [HttpPatch]
        public QuizCheckResponse Check([FromBody] QuizCheckRequest quizCheck)
        {
            var correctAnswers = this.db.QuestionQuizzes
                .Where(qq => qq.QuizId == quizCheck.Id)
                .Select(qq => new UserSelection {
                    QuestionId = qq.QuestionId,
                    AnswerId = qq.Question.Answers.FirstOrDefault(a => a.IsCorrect).Id
                })
                .ToHashSet();

            var response = new QuizCheckResponse
            {
                Correct = 0,
                Wrong = 0
            };

            foreach (var selection in quizCheck.Selections)
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

            return response;
        }
    }
}
