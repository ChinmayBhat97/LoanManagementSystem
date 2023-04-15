using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Migrations
{
    public partial class InitforWaterfallServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "servicesforWaterfalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    srvcName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicesforWaterfalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Waterfalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wtrflName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waterfalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterfallServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wID = table.Column<int>(type: "int", nullable: false),
                    srWID = table.Column<int>(type: "int", nullable: false),
                    activeStatus = table.Column<bool>(type: "bit", nullable: false),
                    OrdrPull = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterfallServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterfallServices_servicesforWaterfalls_srWID",
                        column: x => x.srWID,
                        principalTable: "servicesforWaterfalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaterfallServices_Waterfalls_wID",
                        column: x => x.wID,
                        principalTable: "Waterfalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterfallServices_srWID",
                table: "WaterfallServices",
                column: "srWID");

            migrationBuilder.CreateIndex(
                name: "IX_WaterfallServices_wID",
                table: "WaterfallServices",
                column: "wID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterfallServices");

            migrationBuilder.DropTable(
                name: "servicesforWaterfalls");

            migrationBuilder.DropTable(
                name: "Waterfalls");
        }
    }
}
