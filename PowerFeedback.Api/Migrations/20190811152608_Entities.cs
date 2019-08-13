using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerFeedback.Api.Migrations
{
    public partial class Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextEntities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    SubType = table.Column<string>(nullable: true),
                    SentimentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextEntities_Sentiments_SentimentId",
                        column: x => x.SentimentId,
                        principalTable: "Sentiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TextEntitiesMatch",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TextEntityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextEntitiesMatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextEntitiesMatch_TextEntities_TextEntityId",
                        column: x => x.TextEntityId,
                        principalTable: "TextEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextEntities_SentimentId",
                table: "TextEntities",
                column: "SentimentId");

            migrationBuilder.CreateIndex(
                name: "IX_TextEntitiesMatch_TextEntityId",
                table: "TextEntitiesMatch",
                column: "TextEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextEntitiesMatch");

            migrationBuilder.DropTable(
                name: "TextEntities");
        }
    }
}
