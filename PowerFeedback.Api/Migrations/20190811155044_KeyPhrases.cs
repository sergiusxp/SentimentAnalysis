using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerFeedback.Api.Migrations
{
    public partial class KeyPhrases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyPhrases",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    SentimentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyPhrases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyPhrases_Sentiments_SentimentId",
                        column: x => x.SentimentId,
                        principalTable: "Sentiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyPhrases_SentimentId",
                table: "KeyPhrases",
                column: "SentimentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyPhrases");
        }
    }
}
