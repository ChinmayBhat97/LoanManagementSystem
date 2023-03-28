using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Migrations
{
    public partial class InitScorecard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    aID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.aID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    sID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.sID);
                });

            migrationBuilder.CreateTable(
                name: "ScoreCards",
                columns: table => new
                {
                    scID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    minIncome = table.Column<double>(type: "float", nullable: false),
                    maxIncome = table.Column<double>(type: "float", nullable: false),
                    stateId = table.Column<int>(type: "int", nullable: false),
                    acntId = table.Column<int>(type: "int", nullable: false),
                    minLoanamt = table.Column<double>(type: "float", nullable: false),
                    maxLoanamt = table.Column<double>(type: "float", nullable: false),
                    routingBlcklst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipcodeBlcklst = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreCards", x => x.scID);
                    table.ForeignKey(
                        name: "FK_ScoreCards_Accounts_acntId",
                        column: x => x.acntId,
                        principalTable: "Accounts",
                        principalColumn: "aID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreCards_States_stateId",
                        column: x => x.stateId,
                        principalTable: "States",
                        principalColumn: "sID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_acntId",
                table: "ScoreCards",
                column: "acntId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_stateId",
                table: "ScoreCards",
                column: "stateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreCards");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
