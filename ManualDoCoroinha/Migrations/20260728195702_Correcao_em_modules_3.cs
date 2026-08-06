using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManualDoCoroinha.Migrations
{
    /// <inheritdoc />
    public partial class Correcao_em_modules_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Modules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PrerequisiteId",
                table: "Modules",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PrerequisiteUserModuleId",
                table: "Modules",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_PrerequisiteUserModuleId",
                table: "Modules",
                column: "PrerequisiteUserModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_UserModules_PrerequisiteUserModuleId",
                table: "Modules",
                column: "PrerequisiteUserModuleId",
                principalTable: "UserModules",
                principalColumn: "UserModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_UserModules_PrerequisiteUserModuleId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_PrerequisiteUserModuleId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "PrerequisiteId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "PrerequisiteUserModuleId",
                table: "Modules");
        }
    }
}
