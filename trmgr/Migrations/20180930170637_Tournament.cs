﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trmgr.Migrations
{
    public partial class Tournament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    MaxAge = table.Column<byte>(nullable: false),
                    MinAge = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderCaegories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderCaegories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetAddress = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    RegistrationStart = table.Column<DateTime>(nullable: false),
                    RegistrationEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournament_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeightCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    MinWeight = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    MaxWeight = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    Absolute = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brackets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoGi = table.Column<bool>(nullable: false),
                    WeightClassId = table.Column<int>(nullable: true),
                    AgeCategoryId = table.Column<int>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    TournamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brackets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brackets_AgeCategories_AgeCategoryId",
                        column: x => x.AgeCategoryId,
                        principalTable: "AgeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Brackets_GenderCaegories_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderCaegories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Brackets_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Brackets_WeightCategories_WeightClassId",
                        column: x => x.WeightClassId,
                        principalTable: "WeightCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SeedNumber = table.Column<int>(nullable: false),
                    Competitor1Id = table.Column<string>(nullable: true),
                    Competitor2Id = table.Column<string>(nullable: true),
                    WinnerMatchId = table.Column<int>(nullable: true),
                    Score1 = table.Column<byte>(nullable: false),
                    Score2 = table.Column<byte>(nullable: false),
                    Advantages1 = table.Column<byte>(nullable: false),
                    Advantages2 = table.Column<byte>(nullable: false),
                    Penalties1 = table.Column<byte>(nullable: false),
                    Penalties2 = table.Column<byte>(nullable: false),
                    IsCompetitor1DQed = table.Column<bool>(nullable: false),
                    IsCompetitor2DQed = table.Column<bool>(nullable: false),
                    BracketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Brackets_BracketId",
                        column: x => x.BracketId,
                        principalTable: "Brackets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_AspNetUsers_Competitor1Id",
                        column: x => x.Competitor1Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_AspNetUsers_Competitor2Id",
                        column: x => x.Competitor2Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Matches_WinnerMatchId",
                        column: x => x.WinnerMatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brackets_AgeCategoryId",
                table: "Brackets",
                column: "AgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Brackets_GenderId",
                table: "Brackets",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Brackets_TournamentId",
                table: "Brackets",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Brackets_WeightClassId",
                table: "Brackets",
                column: "WeightClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_BracketId",
                table: "Matches",
                column: "BracketId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Competitor1Id",
                table: "Matches",
                column: "Competitor1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Competitor2Id",
                table: "Matches",
                column: "Competitor2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerMatchId",
                table: "Matches",
                column: "WinnerMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_CityId",
                table: "Tournament",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Brackets");

            migrationBuilder.DropTable(
                name: "AgeCategories");

            migrationBuilder.DropTable(
                name: "GenderCaegories");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "WeightCategories");
        }
    }
}
