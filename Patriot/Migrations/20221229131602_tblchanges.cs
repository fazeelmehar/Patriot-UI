using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patriot.Migrations
{
    public partial class tblchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPTLetters");

            migrationBuilder.CreateTable(
                name: "MasterLetters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    ImportDate = table.Column<DateTime>(nullable: false),
                    LetterGeneratedIndex = table.Column<int>(nullable: false),
                    LoggedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterLetters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterLetters");

            migrationBuilder.CreateTable(
                name: "CPTLetters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLetterWasMailed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatesOfCPTLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPTLetters", x => x.Id);
                });
        }
    }
}
