using Microsoft.EntityFrameworkCore.Migrations;

namespace InlämningsUppgiftASP.NET.Data.Migrations
{
    public partial class ClassName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "SchoolClasses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "SchoolClasses");
        }
    }
}
