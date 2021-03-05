using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Quiz.Server.Data;
using Quiz.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Quiz.Tests
{
    public class QuizServiceTests
    {
        [Fact]
        public async Task GetCategories_Should_ReturnAllCategories()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                 .UseInMemoryDatabase(databaseName: "quiz")
                 .Options;

            using (var context = new DataContext(options))
            {
                var service = new QuizService(context);

                context.Categories.Add(new Category() { Id = 1, Name = "TestCategory", Questions = new List<Question>() });
                context.Categories.Add(new Category() { Id = 2, Name = "TestCategory2", Questions = new List<Question>() });
                context.SaveChanges();

                var categories = service.GetCategories();

                categories.Count.Should().Be(2);
                categories[0].Name.Should().Be("TestCategory");
            }
        }

        [Fact]
        public async Task CreateAsync_Should_ReturnCorrectQuiz()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                            .UseInMemoryDatabase(databaseName: "quiz")
                            .Options;

            using (var context = new DataContext(options))
            {
                const string userId = "test";
                var service = new QuizService(context);

                context.Questions.Add(new Question() { Id = 1 });
                context.Questions.Add(new Question() { Id = 2 });
                context.Questions.Add(new Question() { Id = 3 });
                context.Questions.Add(new Question() { Id = 4 });
                context.Questions.Add(new Question() { Id = 5 });
                context.SaveChanges();

                var quizId = await service.CreateAsync(userId);
                quizId.Should().Be(1);

                var questionQuizzes = context.QuestionQuizzes.Where(x => x.QuizId == quizId).ToList();
                questionQuizzes.Count.Should().Be(5);
            }
        }
    }
}
