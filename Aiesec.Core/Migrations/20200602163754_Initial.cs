using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aiesec.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FunctionalFieldType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Acronym = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalFieldType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePhotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    Path = table.Column<string>(nullable: true),
                    FileSystemPath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SizeInBytes = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    Height = table.Column<float>(nullable: false),
                    Width = table.Column<float>(nullable: false),
                    XResolution = table.Column<float>(nullable: false),
                    YResolution = table.Column<float>(nullable: false),
                    ResolutionUnit = table.Column<string>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePhotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalCommittee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    EstablishmentDate = table.Column<DateTime>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    NumberOfTeams = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalCommittee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalCommittee_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    Biography = table.Column<string>(maxLength: 500, nullable: true, defaultValue: "AIESEC-er"),
                    CityId = table.Column<int>(nullable: false),
                    ProfileTeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(nullable: false),
                    FunctionalFieldTypeId = table.Column<int>(nullable: false),
                    LocalCommitteeId = table.Column<int>(nullable: false),
                    NumberOfMembers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_FunctionalFieldType_FunctionalFieldTypeId",
                        column: x => x.FunctionalFieldTypeId,
                        principalTable: "FunctionalFieldType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_LocalCommittee_LocalCommitteeId",
                        column: x => x.LocalCommitteeId,
                        principalTable: "LocalCommittee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    LeaveDate = table.Column<DateTime>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileTeam_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalCommittee_CityId",
                table: "LocalCommittee",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CityId",
                table: "Profiles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTeam_ProfileId",
                table: "ProfileTeam",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTeam_TeamId",
                table: "ProfileTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_FunctionalFieldTypeId",
                table: "Team",
                column: "FunctionalFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_LocalCommitteeId",
                table: "Team",
                column: "LocalCommitteeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfilePhotos");

            migrationBuilder.DropTable(
                name: "ProfileTeam");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "FunctionalFieldType");

            migrationBuilder.DropTable(
                name: "LocalCommittee");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
