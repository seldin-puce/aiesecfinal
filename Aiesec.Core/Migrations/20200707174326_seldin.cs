using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aiesec.Database.Migrations
{
    public partial class seldin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(   
                name: "EstablishmentDate",
                table: "Office",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstablishmentDate",
                table: "Office");
        }
    }
}
