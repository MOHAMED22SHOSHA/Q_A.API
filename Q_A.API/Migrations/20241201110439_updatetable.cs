using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Q_A.API.Migrations
{
    /// <inheritdoc />
    public partial class updatetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AnswerCreatedAt",
                table: "question",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "QuestionCreatedAt",
                table: "question",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerCreatedAt",
                table: "question");

            migrationBuilder.DropColumn(
                name: "QuestionCreatedAt",
                table: "question");
        }
    }
}
