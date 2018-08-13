using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsLiveScoreboard.Data.Migrations
{
    public partial class GameOptionsAddedPlusSomeDateTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Matches_MatchId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Matches_MatchId1",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_MatchId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_MatchId1",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "MatchId1",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "IsGamePlayable",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "IsPeriodPlayable",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "IsSetPlayable",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "MaxGamesCount",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "MaxSetsCount",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "PeriodNumber",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "GameOptionsId",
                table: "Scores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameOptionsId1",
                table: "Scores",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualStartTime",
                table: "Matches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OptionsId",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledStartTime",
                table: "Matches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GameOptionsId",
                table: "GameRooms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GameOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsGamePlayable = table.Column<bool>(nullable: false),
                    MaxGamesCount = table.Column<int>(nullable: false),
                    IsPeriodPlayable = table.Column<bool>(nullable: false),
                    PeriodNumber = table.Column<int>(nullable: false),
                    IsSetPlayable = table.Column<bool>(nullable: false),
                    MaxSetsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_GameOptionsId",
                table: "Scores",
                column: "GameOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_GameOptionsId1",
                table: "Scores",
                column: "GameOptionsId1");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_OptionsId",
                table: "Matches",
                column: "OptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRooms_GameOptionsId",
                table: "GameRooms",
                column: "GameOptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameRooms_GameOptions_GameOptionsId",
                table: "GameRooms",
                column: "GameOptionsId",
                principalTable: "GameOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_GameOptions_OptionsId",
                table: "Matches",
                column: "OptionsId",
                principalTable: "GameOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_GameOptions_GameOptionsId",
                table: "Scores",
                column: "GameOptionsId",
                principalTable: "GameOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_GameOptions_GameOptionsId1",
                table: "Scores",
                column: "GameOptionsId1",
                principalTable: "GameOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameRooms_GameOptions_GameOptionsId",
                table: "GameRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_GameOptions_OptionsId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_GameOptions_GameOptionsId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_GameOptions_GameOptionsId1",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "GameOptions");

            migrationBuilder.DropIndex(
                name: "IX_Scores_GameOptionsId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_GameOptionsId1",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Matches_OptionsId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_GameRooms_GameOptionsId",
                table: "GameRooms");

            migrationBuilder.DropColumn(
                name: "GameOptionsId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "GameOptionsId1",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "ActualStartTime",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "OptionsId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ScheduledStartTime",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "GameOptionsId",
                table: "GameRooms");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "MatchId",
                table: "Scores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatchId1",
                table: "Scores",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGamePlayable",
                table: "Matches",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPeriodPlayable",
                table: "Matches",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSetPlayable",
                table: "Matches",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxGamesCount",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxSetsCount",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodNumber",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_MatchId",
                table: "Scores",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_MatchId1",
                table: "Scores",
                column: "MatchId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Matches_MatchId",
                table: "Scores",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Matches_MatchId1",
                table: "Scores",
                column: "MatchId1",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
