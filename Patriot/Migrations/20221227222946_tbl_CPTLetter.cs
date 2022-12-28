using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patriot.Migrations
{
    public partial class tbl_CPTLetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPTLetters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<string>(nullable: true),
                    VisitNo = table.Column<string>(nullable: true),
                    PatientLastName = table.Column<string>(nullable: true),
                    PatientFirstName = table.Column<string>(nullable: true),
                    DOS = table.Column<DateTime>(nullable: false),
                    CheckAmount = table.Column<decimal>(nullable: false),
                    DatesOfCPTLetter = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DateLetterWasMailed = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPTLetters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPTLetters");
        }
    }
}
