using Microsoft.EntityFrameworkCore.Migrations;

namespace InlämningsUppgiftASP.NET.Data.Migrations
{
    public partial class Students : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
