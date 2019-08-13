using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerFeedbackClientServer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    ContactType = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sentiments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContactId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentiments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sentiments_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sentiments_ContactId",
                table: "Sentiments",
                column: "ContactId",
                unique: true,
                filter: "[ContactId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentiments");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
