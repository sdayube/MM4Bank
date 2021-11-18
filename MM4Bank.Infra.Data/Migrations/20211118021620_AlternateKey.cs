using Microsoft.EntityFrameworkCore.Migrations;

namespace MM4Bank.Infra.Data.Migrations
{
    public partial class AlternateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_TB_ACCOUNT_NR_ACCOUNT",
                table: "TB_ACCOUNT",
                column: "NR_ACCOUNT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TB_ACCOUNT_NR_ACCOUNT",
                table: "TB_ACCOUNT");
        }
    }
}
