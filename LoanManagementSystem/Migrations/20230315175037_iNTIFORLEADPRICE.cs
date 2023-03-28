using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Migrations
{
    public partial class iNTIFORLEADPRICE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeadPrices",
                columns: table => new
                {
                    lpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ETAA5000 = table.Column<double>(type: "float", nullable: false),
                    ETAA4000 = table.Column<double>(type: "float", nullable: false),
                    ETAA3000 = table.Column<double>(type: "float", nullable: false),
                    ETAA2000 = table.Column<double>(type: "float", nullable: false),
                    ETAB1999 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadPrices", x => x.lpId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeadPrices");
        }
    }
}
