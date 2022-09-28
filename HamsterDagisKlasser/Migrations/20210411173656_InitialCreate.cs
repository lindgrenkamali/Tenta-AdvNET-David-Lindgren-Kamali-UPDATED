using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HamsterDatabaseStructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcivityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    CageID = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.CageID);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 1, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hamsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HamsterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CageId = table.Column<int>(type: "int", nullable: true),
                    ExerciseAreaId = table.Column<int>(type: "int", nullable: true),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LatestMotion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hamsters_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "CageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_ExerciseAreas_ExerciseAreaId",
                        column: x => x.ExerciseAreaId,
                        principalTable: "ExerciseAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HamsterId = table.Column<int>(type: "int", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Hamsters_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "Hamsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "AcivityName" },
                values: new object[,]
                {
                    { 1, "CheckIn" },
                    { 2, "CheckOut" },
                    { 3, "ToCage" },
                    { 4, "ExerciseArea" }
                });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "CageID", "MaxSize" },
                values: new object[,]
                {
                    { 9, 3 },
                    { 8, 3 },
                    { 7, 3 },
                    { 6, 3 },
                    { 10, 3 },
                    { 4, 3 },
                    { 3, 3 },
                    { 2, 3 },
                    { 1, 3 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "ExerciseAreas",
                columns: new[] { "Id", "MaxSize" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "OwnerName" },
                values: new object[,]
                {
                    { 15, "Mork of Ork" },
                    { 16, "Mindy Mendel" },
                    { 17, "GW Hansson" },
                    { 18, "Pia Hansson" },
                    { 19, "Bo Ek" },
                    { 22, "Carita Gran" },
                    { 21, "Hans Björk" },
                    { 23, "Mia Eriksson" },
                    { 24, "Anna Linström" },
                    { 14, "Kim Carnes" },
                    { 20, "Anna Al" },
                    { 13, "Bette Davis" },
                    { 6, "Anfers Murkwood" },
                    { 11, "Bobby Ewing" },
                    { 10, "Lorenzo Lamas" },
                    { 9, "Bianca Ingrosso" },
                    { 8, "Pernilla Wahlgren" },
                    { 7, "Anna Book" },
                    { 25, "Lennart Berg" },
                    { 5, "Ottilla Murkwood" },
                    { 4, "Jan Hallgren" },
                    { 3, "Lisa Nilsson" },
                    { 2, "Carl Hamilton" },
                    { 1, "Kallegurra Aktersnurra" },
                    { 12, "Hedy Lamar" },
                    { 26, "Bo Bergman" }
                });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "Id", "Age", "CageId", "CheckInTime", "ExerciseAreaId", "Gender", "HamsterName", "LatestMotion", "OwnerId" },
                values: new object[,]
                {
                    { 1, 4, null, null, null, "M", "Rufus", null, 1 },
                    { 28, 8, null, null, null, "M", "Marvel", null, 24 },
                    { 27, 9, null, null, null, "F", "Mimmi", null, 23 },
                    { 26, 110, null, null, null, "M", "Crawler", null, 22 },
                    { 25, 12, null, null, null, "F", "Gittan", null, 21 },
                    { 24, 14, null, null, null, "M", "Sauron", null, 20 },
                    { 23, 15, null, null, null, "M", "Clint", null, 19 },
                    { 22, 16, null, null, null, "F", "Neko", null, 18 },
                    { 21, 16, null, null, null, "F", "Fiffi", null, 17 },
                    { 20, 18, null, null, null, "F", "Ruby", null, 16 },
                    { 19, 19, null, null, null, "F", "Kimber", null, 15 },
                    { 18, 20, null, null, null, "F", "Amber", null, 14 },
                    { 17, 21, null, null, null, "M", "Robin", null, 13 },
                    { 16, 22, null, null, null, "F", "Bobo", null, 12 },
                    { 15, 23, null, null, null, "M", "Beppe", null, 11 },
                    { 14, 24, null, null, null, "M", "Bulle", null, 10 },
                    { 13, 3, null, null, null, "F", "Malin", null, 9 },
                    { 12, 3, null, null, null, "M", "Chivas", null, 8 },
                    { 11, 4, null, null, null, "F", "Starlight", null, 7 },
                    { 10, 4, null, null, null, "M", "Kurt", null, 7 },
                    { 9, 5, null, null, null, "M", "Kalle", null, 6 },
                    { 8, 6, null, null, null, "F", "Miss Diggy", null, 5 },
                    { 7, 7, null, null, null, "F", "Mulan", null, 4 },
                    { 6, 8, null, null, null, "F", "Sussi", null, 3 },
                    { 5, 9, null, null, null, "M", "Sneaky", null, 3 },
                    { 4, 10, null, null, null, "M", "Nibbler", null, 2 },
                    { 3, 11, null, null, null, "M", "Fluff", null, 2 },
                    { 2, 12, null, null, null, "F", "Lisa", null, 1 },
                    { 29, 7, null, null, null, "M", "Storm", null, 25 },
                    { 30, 6, null, null, null, "F", "Busan", null, 26 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_ActivityId",
                table: "ActivityLogs",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_HamsterId",
                table: "ActivityLogs",
                column: "HamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_CageId",
                table: "Hamsters",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_ExerciseAreaId",
                table: "Hamsters",
                column: "ExerciseAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_OwnerId",
                table: "Hamsters",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Hamsters");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropTable(
                name: "ExerciseAreas");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
