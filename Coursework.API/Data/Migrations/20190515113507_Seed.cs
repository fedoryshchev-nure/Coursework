using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35295c9a-ccbd-4421-912b-b2779fde0fb4", "a4a9fe9a-97c1-4ddb-b78d-ea24e7516799", "Admin", "ADMIN" },
                    { "00633023-d00e-4a73-88fe-08758273e25b", "380ff609-2321-4078-9b15-35b32b5484ee", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "DateReleased", "Description", "Name" },
                values: new object[,]
                {
                    { "1", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8152), "Game one description", "Game one" },
                    { "2", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8156), "Game two description", "Game two" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Team one" },
                    { "2", "Team two" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "GameId", "MatchResult", "TeamOneId", "TeamTwoId" },
                values: new object[,]
                {
                    { "1", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8178), "1", 0, "1", "2" },
                    { "2", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8181), "1", 3, "1", "2" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Nickname", "TeamId" },
                values: new object[,]
                {
                    { "1", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8022), "FirstName", "LastName", "Player 1", "1" },
                    { "2", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8049), "FirstName", "LastName", "Player 2", "1" },
                    { "3", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8052), "FirstName", "LastName", "Player 3", "1" },
                    { "4", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8056), "FirstName", "LastName", "Player 4", "1" },
                    { "5", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8059), "FirstName", "LastName", "Player 5", "1" },
                    { "6", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8061), "FirstName", "LastName", "Player 6", "2" },
                    { "7", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8064), "FirstName", "LastName", "Player 7", "2" },
                    { "8", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8067), "FirstName", "LastName", "Player 8", "2" },
                    { "9", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8070), "FirstName", "LastName", "Player 9", "2" },
                    { "10", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8072), "FirstName", "LastName", "Player 10", "2" }
                });

            migrationBuilder.InsertData(
                table: "BioMeasures",
                columns: new[] { "Id", "DateMeasured", "MatchId", "PlayerId", "Pressure", "Pulse" },
                values: new object[,]
                {
                    { "1", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8209), "1", "1", 80, 90 },
                    { "19", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8258), "2", "9", 100, 79 },
                    { "9", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8231), "1", "9", 62, 67 },
                    { "18", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8255), "2", "8", 200, 30 },
                    { "8", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8229), "1", "8", 30, 20 },
                    { "17", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8253), "2", "7", 60, 60 },
                    { "7", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8226), "1", "7", 160, 160 },
                    { "16", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8250), "2", "6", 140, 150 },
                    { "6", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8223), "1", "6", 150, 40 },
                    { "15", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8247), "2", "5", 80, 90 },
                    { "14", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8245), "2", "4", 70, 120 },
                    { "13", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8242), "2", "3", 120, 87 },
                    { "12", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8239), "2", "2", 83, 90 },
                    { "11", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8237), "2", "1", 100, 80 },
                    { "5", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8220), "1", "5", 84, 80 },
                    { "4", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8218), "1", "4", 80, 70 },
                    { "3", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8215), "1", "3", 75, 95 },
                    { "2", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8212), "1", "2", 90, 100 },
                    { "10", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8234), "1", "10", 400, 400 },
                    { "20", new DateTime(2019, 5, 15, 14, 35, 6, 653, DateTimeKind.Local).AddTicks(8261), "2", "10", 87, 93 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00633023-d00e-4a73-88fe-08758273e25b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35295c9a-ccbd-4421-912b-b2779fde0fb4");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "13");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "14");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "15");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "16");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "17");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "18");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "19");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "20");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "BioMeasures",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
