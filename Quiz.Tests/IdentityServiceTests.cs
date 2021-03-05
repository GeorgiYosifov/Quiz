using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Quiz.Server.Data;
using Quiz.Server.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Quiz.Tests
{
    public class IdentityServiceTests
    {
        [Fact]
        public async Task LoginAsync_Should_ReturnCorrectData()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                  .UseInMemoryDatabase(databaseName: "quiz")
                  .Options;

            using (var context = new DataContext(options))
            {
                await CleanUpUsers(context);

                const string username = "test";
                var service = new IdentityService(context);
                var response = await service.LoginAsync(username);

                response.Username.Should().Be(username);
                var actual = await context.Users.CountAsync();
                actual.Should().Be(1);
            }
        }

        private static async Task CleanUpUsers(DataContext context)
        {
            var users = await context.Users.ToListAsync();
            context.Users.RemoveRange(users);
        }

        [Fact]
        public async Task LogoutAsync_Should_SetIsLoggedInToFalse()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "quiz")
                .Options;

            using (var context = new DataContext(options))
            {
                const string username = "test";
                var service = new IdentityService(context);
                var response = await service.LoginAsync(username);

                response.Username.Should().Be(username);

                await service.LogoutAsync(response.Id);

                var actual = await context.Users.FirstOrDefaultAsync(x => x.Id == response.Id);
                actual.IsLoggedIn.Should().BeFalse();
            }
        }
    }
}
