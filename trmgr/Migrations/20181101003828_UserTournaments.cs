using Microsoft.EntityFrameworkCore.Migrations;

namespace trmgr.Migrations
{
    public partial class UserTournaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brackets_Tournament_TournamentId",
                table: "Brackets");

            migrationBuilder.DropForeignKey(
                name: "FK_DivisionGroup_Tournament_TournamentId",
                table: "DivisionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_AspNetUsers_ApplicationUserId",
                table: "Tournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Cities_CityId",
                table: "Tournament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tournament",
                table: "Tournament");

            migrationBuilder.RenameTable(
                name: "Tournament",
                newName: "Tournaments");

            migrationBuilder.RenameIndex(
                name: "IX_Tournament_CityId",
                table: "Tournaments",
                newName: "IX_Tournaments_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tournament_ApplicationUserId",
                table: "Tournaments",
                newName: "IX_Tournaments_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brackets_Tournaments_TournamentId",
                table: "Brackets",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DivisionGroup_Tournaments_TournamentId",
                table: "DivisionGroup",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_AspNetUsers_ApplicationUserId",
                table: "Tournaments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brackets_Tournaments_TournamentId",
                table: "Brackets");

            migrationBuilder.DropForeignKey(
                name: "FK_DivisionGroup_Tournaments_TournamentId",
                table: "DivisionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_AspNetUsers_ApplicationUserId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Cities_CityId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments");

            migrationBuilder.RenameTable(
                name: "Tournaments",
                newName: "Tournament");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_CityId",
                table: "Tournament",
                newName: "IX_Tournament_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_ApplicationUserId",
                table: "Tournament",
                newName: "IX_Tournament_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tournament",
                table: "Tournament",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brackets_Tournament_TournamentId",
                table: "Brackets",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DivisionGroup_Tournament_TournamentId",
                table: "DivisionGroup",
                column: "TournamentId",
                principalTable: "Tournament",
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
                name: "FK_Tournament_Cities_CityId",
                table: "Tournament",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
