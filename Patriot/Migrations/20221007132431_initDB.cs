using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patriot.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Message = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
