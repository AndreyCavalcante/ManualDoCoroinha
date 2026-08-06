using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManualDoCoroinha.Migrations
{
    /// <inheritdoc />
    public partial class Categoria_modules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Modules");
        }
    }
}
