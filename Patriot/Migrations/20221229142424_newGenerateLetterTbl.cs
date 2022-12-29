using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patriot.Migrations
{
    public partial class newGenerateLetterTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenerateLetters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MasterLetterId = table.Column<Guid>(nullable: false),
                    Client = table.Column<string>(nullable: true),
                    Entity = table.Column<string>(nullable: true),
                    LetterType = table.Column<string>(nullable: true),
                    VisitNo = table.Column<string>(nullable: true),
                    InsuranceName = table.Column<string>(nullable: true),
                    InsuranceID = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    DOS = table.Column<DateTime>(nullable: false),
                    CheckAmount = table.Column<decimal>(nullable: false),
                    DateLetterWasMailed = table.Column<DateTime>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    LetterGenerated = table.Column<DateTime>(nullable: true),
                    LetterPrinted = table.Column<DateTime>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    LetterGeneratedIndex = table.Column<int>(nullable: false),
                    LoggedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerateLetters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenerateLetters_MasterLetters_MasterLetterId",
                        column: x => x.MasterLetterId,
                        principalTable: "MasterLetters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenerateLetters_MasterLetterId",
                table: "GenerateLetters",
                column: "MasterLetterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenerateLetters");
        }
    }
}
