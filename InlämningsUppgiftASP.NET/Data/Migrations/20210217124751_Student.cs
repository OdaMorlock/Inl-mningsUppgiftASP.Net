using Microsoft.EntityFrameworkCore.Migrations;

namespace InlämningsUppgiftASP.NET.Data.Migrations
{
    public partial class Student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SchoolClasses_SchoolClassesId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SchoolClassesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolClassesId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "SchoolClasses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_StudentId",
                table: "SchoolClasses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_AspNetUsers_StudentId",
                table: "SchoolClasses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_AspNetUsers_StudentId",
                table: "SchoolClasses");

            migrationBuilder.DropIndex(
                name: "IX_SchoolClasses_StudentId",
                table: "SchoolClasses");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "SchoolClasses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolClassesId",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SchoolClassesId",
                table: "AspNetUsers",
                column: "SchoolClassesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SchoolClasses_SchoolClassesId",
                table: "AspNetUsers",
                column: "SchoolClassesId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
