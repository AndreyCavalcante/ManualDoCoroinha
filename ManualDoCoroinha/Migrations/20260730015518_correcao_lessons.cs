using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManualDoCoroinha.Migrations
{
    /// <inheritdoc />
    public partial class correcao_lessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PrerequisiteId",
                table: "Lessons",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_PrerequisiteId",
                table: "Lessons",
                column: "PrerequisiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Lessons_PrerequisiteId",
                table: "Lessons",
                column: "PrerequisiteId",
                principalTable: "Lessons",
                principalColumn: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Lessons_PrerequisiteId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_PrerequisiteId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "PrerequisiteId",
                table: "Lessons");
        }
    }
}
