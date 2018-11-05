using Microsoft.EntityFrameworkCore.Migrations;

namespace trmgr.Migrations
{
    public partial class TournamentAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DivisionGroup_Tournaments_TournamentId",
                table: "DivisionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Cities_CityId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_CityId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Tournaments");

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "Tournaments",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Tournaments",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Tournaments",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Tournaments",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "DivisionGroup",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DivisionGroup_Tournaments_TournamentId",
                table: "DivisionGroup",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DivisionGroup_Tournaments_TournamentId",
                table: "DivisionGroup");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Tournaments");

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "Tournaments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "DivisionGroup",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_CityId",
                table: "Tournaments",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DivisionGroup_Tournaments_TournamentId",
                table: "DivisionGroup",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Cities_CityId",
                table: "Tournaments",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
