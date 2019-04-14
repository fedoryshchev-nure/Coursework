using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class matchBioMeasureRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchBioMeasures");

            migrationBuilder.AddColumn<string>(
                name: "MatchId",
                table: "BioMeasures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BioMeasures_MatchId",
                table: "BioMeasures",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_BioMeasures_Matches_MatchId",
                table: "BioMeasures",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BioMeasures_Matches_MatchId",
                table: "BioMeasures");

            migrationBuilder.DropIndex(
                name: "IX_BioMeasures_MatchId",
                table: "BioMeasures");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "BioMeasures");

            migrationBuilder.CreateTable(
                name: "MatchBioMeasures",
                columns: table => new
                {
                    MatchId = table.Column<string>(nullable: false),
                    BioMeasureId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchBioMeasures", x => new { x.MatchId, x.BioMeasureId });
                    table.ForeignKey(
                        name: "FK_MatchBioMeasures_BioMeasures_BioMeasureId",
                        column: x => x.BioMeasureId,
                        principalTable: "BioMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchBioMeasures_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchBioMeasures_BioMeasureId",
                table: "MatchBioMeasures",
                column: "BioMeasureId");
        }
    }
}
