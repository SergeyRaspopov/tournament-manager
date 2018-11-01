using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trmgr.Migrations
{
    public partial class Divisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgeCategories_Tournament_TournamentId",
                table: "AgeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceCategories_AgeCategories_AgeCategoryId",
                table: "ExperienceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderCaegories_AgeCategories_AgeCategoryId",
                table: "GenderCaegories");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightCategories_GenderCaegories_GenderCategoryId",
                table: "WeightCategories");

            migrationBuilder.DropIndex(
                name: "IX_GenderCaegories_AgeCategoryId",
                table: "GenderCaegories");

            migrationBuilder.DropColumn(
                name: "AgeCategoryId",
                table: "GenderCaegories");

            migrationBuilder.RenameColumn(
                name: "GenderCategoryId",
                table: "WeightCategories",
                newName: "DivisionGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_WeightCategories_GenderCategoryId",
                table: "WeightCategories",
                newName: "IX_WeightCategories_DivisionGroupId");

            migrationBuilder.RenameColumn(
                name: "AgeCategoryId",
                table: "ExperienceCategories",
                newName: "DivisionGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ExperienceCategories_AgeCategoryId",
                table: "ExperienceCategories",
                newName: "IX_ExperienceCategories_DivisionGroupId");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "AgeCategories",
                newName: "DivisionGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_AgeCategories_TournamentId",
                table: "AgeCategories",
                newName: "IX_AgeCategories_DivisionGroupId");

            migrationBuilder.CreateTable(
                name: "DivisionGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenderCategoryId = table.Column<int>(nullable: true),
                    TournamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivisionGroup_GenderCaegories_GenderCategoryId",
                        column: x => x.GenderCategoryId,
                        principalTable: "GenderCaegories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DivisionGroup_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DivisionGroup_GenderCategoryId",
                table: "DivisionGroup",
                column: "GenderCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DivisionGroup_TournamentId",
                table: "DivisionGroup",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgeCategories_DivisionGroup_DivisionGroupId",
                table: "AgeCategories",
                column: "DivisionGroupId",
                principalTable: "DivisionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceCategories_DivisionGroup_DivisionGroupId",
                table: "ExperienceCategories",
                column: "DivisionGroupId",
                principalTable: "DivisionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightCategories_DivisionGroup_DivisionGroupId",
                table: "WeightCategories",
                column: "DivisionGroupId",
                principalTable: "DivisionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgeCategories_DivisionGroup_DivisionGroupId",
                table: "AgeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceCategories_DivisionGroup_DivisionGroupId",
                table: "ExperienceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightCategories_DivisionGroup_DivisionGroupId",
                table: "WeightCategories");

            migrationBuilder.DropTable(
                name: "DivisionGroup");

            migrationBuilder.RenameColumn(
                name: "DivisionGroupId",
                table: "WeightCategories",
                newName: "GenderCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_WeightCategories_DivisionGroupId",
                table: "WeightCategories",
                newName: "IX_WeightCategories_GenderCategoryId");

            migrationBuilder.RenameColumn(
                name: "DivisionGroupId",
                table: "ExperienceCategories",
                newName: "AgeCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ExperienceCategories_DivisionGroupId",
                table: "ExperienceCategories",
                newName: "IX_ExperienceCategories_AgeCategoryId");

            migrationBuilder.RenameColumn(
                name: "DivisionGroupId",
                table: "AgeCategories",
                newName: "TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_AgeCategories_DivisionGroupId",
                table: "AgeCategories",
                newName: "IX_AgeCategories_TournamentId");

            migrationBuilder.AddColumn<int>(
                name: "AgeCategoryId",
                table: "GenderCaegories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenderCaegories_AgeCategoryId",
                table: "GenderCaegories",
                column: "AgeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgeCategories_Tournament_TournamentId",
                table: "AgeCategories",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceCategories_AgeCategories_AgeCategoryId",
                table: "ExperienceCategories",
                column: "AgeCategoryId",
                principalTable: "AgeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenderCaegories_AgeCategories_AgeCategoryId",
                table: "GenderCaegories",
                column: "AgeCategoryId",
                principalTable: "AgeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightCategories_GenderCaegories_GenderCategoryId",
                table: "WeightCategories",
                column: "GenderCategoryId",
                principalTable: "GenderCaegories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
