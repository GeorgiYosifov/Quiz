using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Server.Migrations
{
    public partial class AddIsLoggedInPropToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "Users");
        }
    }
}
