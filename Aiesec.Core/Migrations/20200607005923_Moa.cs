using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aiesec.Database.Migrations
{
    public partial class Moa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfEstablishment",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Team");

            migrationBuilder.AddColumn<DateTime>(
                name: "EstablishmentDate",
                table: "Team",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "MemberCommittee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    EstablishmentDate = table.Column<DateTime>(nullable: false),
                    Season = table.Column<int>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberCommittee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberCommittee");

            migrationBuilder.DropColumn(
                name: "EstablishmentDate",
                table: "Team");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEstablishment",
                table: "Team",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Team",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
