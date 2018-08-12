using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsLiveScoreboard.Data.Migrations
{
    public partial class GameModelsAlphaVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameRooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SportName = table.Column<string>(maxLength: 50, nullable: false),
                    EventId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRooms_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEvents",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    EventId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_UserEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Competitor1Id = table.Column<int>(nullable: false),
                    Competitor2Id = table.Column<int>(nullable: false),
                    PointsId = table.Column<int>(nullable: true),
                    IsPlayedForTime = table.Column<bool>(nullable: false),
                    MaxGamesCount = table.Column<int>(nullable: false),
                    IsGamePlayable = table.Column<bool>(nullable: false),
                    MaxSetsCount = table.Column<int>(nullable: false),
                    IsSetPlayable = table.Column<bool>(nullable: false),
                    PeriodNumber = table.Column<int>(nullable: false),
                    IsPeriodPlayable = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    WinnerId = table.Column<int>(nullable: true),
                    LoserId = table.Column<int>(nullable: true),
                    GameRoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_GameRooms_GameRoomId",
                        column: x => x.GameRoomId,
                        principalTable: "GameRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    RoomId = table.Column<int>(nullable: true),
                    IsActualPerson = table.Column<bool>(nullable: false),
                    IsTheWinnerOfMatch = table.Column<bool>(nullable: false),
                    CompetitorFromMatchId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitors_Matches_CompetitorFromMatchId",
                        column: x => x.CompetitorFromMatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitors_GameRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "GameRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SequentialNumber = table.Column<int>(nullable: false),
                    Competitor1 = table.Column<int>(nullable: false),
                    Competitor2 = table.Column<int>(nullable: false),
                    MatchId = table.Column<string>(nullable: true),
                    MatchId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scores_Matches_MatchId1",
                        column: x => x.MatchId1,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_CompetitorFromMatchId",
                table: "Competitors",
                column: "CompetitorFromMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_RoomId",
                table: "Competitors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OwnerId",
                table: "Events",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRooms_EventId",
                table: "GameRooms",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Competitor1Id",
                table: "Matches",
                column: "Competitor1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Competitor2Id",
                table: "Matches",
                column: "Competitor2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GameRoomId",
                table: "Matches",
                column: "GameRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LoserId",
                table: "Matches",
                column: "LoserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PointsId",
                table: "Matches",
                column: "PointsId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerId",
                table: "Matches",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_MatchId",
                table: "Scores",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_MatchId1",
                table: "Scores",
                column: "MatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_EventId",
                table: "UserEvents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Competitors_Competitor1Id",
                table: "Matches",
                column: "Competitor1Id",
                principalTable: "Competitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Competitors_Competitor2Id",
                table: "Matches",
                column: "Competitor2Id",
                principalTable: "Competitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Competitors_LoserId",
                table: "Matches",
                column: "LoserId",
                principalTable: "Competitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Competitors_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Competitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Scores_PointsId",
                table: "Matches",
                column: "PointsId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Matches_CompetitorFromMatchId",
                table: "Competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Matches_MatchId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Matches_MatchId1",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Competitors");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "GameRooms");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
