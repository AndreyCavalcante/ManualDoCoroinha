using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManualDoCoroinha.Migrations
{
    /// <inheritdoc />
    public partial class UnlockedQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "QuizUnlocked",
                table: "UserModules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizUnlocked",
                table: "UserModules");
        }
    }
}
