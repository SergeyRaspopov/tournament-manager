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

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "WeightCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Tournament",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GenderCaegories",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "GenderCaegories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "Brackets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AgeCategories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExperienceCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceCategory_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeightCategories_ApplicationUserId",
                table: "WeightCategories",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_ApplicationUserId",
                table: "Tournament",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GenderCaegories_ApplicationUserId",
                table: "GenderCaegories",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brackets_ExperienceId",
                table: "Brackets",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_AgeCategories_ApplicationUserId",
                table: "AgeCategories",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceCategory_ApplicationUserId",
                table: "ExperienceCategory",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgeCategories_AspNetUsers_ApplicationUserId",
                table: "AgeCategories",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brackets_ExperienceCategory_ExperienceId",
                table: "Brackets",
                column: "ExperienceId",
                principalTable: "ExperienceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenderCaegories_AspNetUsers_ApplicationUserId",
                table: "GenderCaegories",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_AspNetUsers_ApplicationUserId",
                table: "Tournament",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightCategories_AspNetUsers_ApplicationUserId",
                table: "WeightCategories",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgeCategories_AspNetUsers_ApplicationUserId",
                table: "AgeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Brackets_ExperienceCategory_ExperienceId",
                table: "Brackets");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderCaegories_AspNetUsers_ApplicationUserId",
                table: "GenderCaegories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_AspNetUsers_ApplicationUserId",
                table: "Tournament");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightCategories_AspNetUsers_ApplicationUserId",
                table: "WeightCategories");

            migrationBuilder.DropTable(
                name: "ExperienceCategory");

            migrationBuilder.DropIndex(
                name: "IX_WeightCategories_ApplicationUserId",
                table: "WeightCategories");

            migrationBuilder.DropIndex(
                name: "IX_Tournament_ApplicationUserId",
                table: "Tournament");

            migrationBuilder.DropIndex(
                name: "IX_GenderCaegories_ApplicationUserId",
                table: "GenderCaegories");

            migrationBuilder.DropIndex(
                name: "IX_Brackets_ExperienceId",
                table: "Brackets");

            migrationBuilder.DropIndex(
                name: "IX_AgeCategories_ApplicationUserId",
                table: "AgeCategories");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "WeightCategories");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "GenderCaegories");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "Brackets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AgeCategories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GenderCaegories",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
