using Microsoft.EntityFrameworkCore.Migrations;

namespace InlämningsUppgiftASP.NET.Data.Migrations
{
    public partial class StudentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "SchoolClasses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "SchoolClasses");
        }
    }
}
