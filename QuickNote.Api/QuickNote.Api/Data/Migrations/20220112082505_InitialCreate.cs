using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickNote.Api.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NotebookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Notebooks_NotebookId",
                        column: x => x.NotebookId,
                        principalTable: "Notebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Notebooks",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "code" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreatedTime", "ModifiedTime", "NotebookId", "Title" },
                values: new object[] { 1, "Console.Writeline(\"Hello World!\");", new DateTimeOffset(new DateTime(2022, 1, 12, 11, 25, 5, 241, DateTimeKind.Unspecified).AddTicks(6967), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 12, 11, 25, 5, 245, DateTimeKind.Unspecified).AddTicks(5727), new TimeSpan(0, 3, 0, 0, 0)), 1, "C#" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreatedTime", "ModifiedTime", "NotebookId", "Title" },
                values: new object[] { 2, "console.log('Hello World!');", new DateTimeOffset(new DateTime(2022, 1, 12, 11, 25, 5, 245, DateTimeKind.Unspecified).AddTicks(8651), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 12, 11, 25, 5, 245, DateTimeKind.Unspecified).AddTicks(8671), new TimeSpan(0, 3, 0, 0, 0)), 1, "Javascript" });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NotebookId",
                table: "Notes",
                column: "NotebookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Notebooks");
        }
    }
}
