using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trmgr.Migrations
{
    public partial class Organization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Division",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "AgeCategoryGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCategoryGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgeCategoryGroup_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceCategoryGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceCategoryGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceCategoryGroup_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenderCategoryGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderCategoryGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenderCategoryGroup_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    RegistrationEnd = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournament_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournament_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeightCategoryGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightCategoryGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightCategoryGroup_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    MaxAge = table.Column<byte>(nullable: false),
                    MinAge = table.Column<byte>(nullable: false),
                    AgeCategoryGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgeCategories_AgeCategoryGroup_AgeCategoryGroupId",
                        column: x => x.AgeCategoryGroupId,
                        principalTable: "AgeCategoryGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ExperienceCategoryGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceCategory_ExperienceCategoryGroup_ExperienceCategoryGroupId",
                        column: x => x.ExperienceCategoryGroupId,
                        principalTable: "ExperienceCategoryGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenderCaegories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    GenderCategoryGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderCaegories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenderCaegories_GenderCategoryGroup_GenderCategoryGroupId",
                        column: x => x.GenderCategoryGroupId,
                        principalTable: "GenderCategoryGroup",
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
                    Absolute = table.Column<bool>(nullable: false),
                    WeightCategoryGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightCategories_WeightCategoryGroup_WeightCategoryGroupId",
                        column: x => x.WeightCategoryGroupId,
                        principalTable: "WeightCategoryGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    ExperienceId = table.Column<int>(nullable: true),
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
                        name: "FK_Brackets_ExperienceCategory_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "ExperienceCategory",
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
                name: "IX_AgeCategories_AgeCategoryGroupId",
                table: "AgeCategories",
                column: "AgeCategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AgeCategoryGroup_ApplicationUserId",
                table: "AgeCategoryGroup",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brackets_AgeCategoryId",
                table: "Brackets",
                column: "AgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Brackets_ExperienceId",
                table: "Brackets",
                column: "ExperienceId");

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
                name: "IX_ExperienceCategory_ExperienceCategoryGroupId",
                table: "ExperienceCategory",
                column: "ExperienceCategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceCategoryGroup_ApplicationUserId",
                table: "ExperienceCategoryGroup",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GenderCaegories_GenderCategoryGroupId",
                table: "GenderCaegories",
                column: "GenderCategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GenderCategoryGroup_ApplicationUserId",
                table: "GenderCategoryGroup",
                column: "ApplicationUserId");

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
                name: "IX_Tournament_ApplicationUserId",
                table: "Tournament",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_CityId",
                table: "Tournament",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightCategories_WeightCategoryGroupId",
                table: "WeightCategories",
                column: "WeightCategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightCategoryGroup_ApplicationUserId",
                table: "WeightCategoryGroup",
                column: "ApplicationUserId");
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
                name: "ExperienceCategory");

            migrationBuilder.DropTable(
                name: "GenderCaegories");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "WeightCategories");

            migrationBuilder.DropTable(
                name: "AgeCategoryGroup");

            migrationBuilder.DropTable(
                name: "ExperienceCategoryGroup");

            migrationBuilder.DropTable(
                name: "GenderCategoryGroup");

            migrationBuilder.DropTable(
                name: "WeightCategoryGroup");

            migrationBuilder.AddColumn<int>(
                name: "Division",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
