using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Quiz.Server.Data;
using Quiz.Server.Services;
using System;
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
                  .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                  .Options;

            using (var context = new DataContext(options))
            {
                const string username = "test";
                var service = new IdentityService(context);
                var response = await service.LoginAsync(username);

                response.Username.Should().Be(username);
                var actual = await context.Users.CountAsync();
                actual.Should().Be(1);
            }
        }

        [Fact]
        public async Task LogoutAsync_Should_SetIsLoggedInToFalse()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
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
