using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Q_A.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.QuestionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "question");
        }
    }
}
