using Microsoft.EntityFrameworkCore.Migrations;

namespace MM4Bank.Infra.Data.Migrations
{
    public partial class CascadeOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLIENT_TB_ACCOUNT_ID_ACCOUNT",
                table: "TB_CLIENT");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLIENT_TB_ACCOUNT_ID_ACCOUNT",
                table: "TB_CLIENT",
                column: "ID_ACCOUNT",
                principalTable: "TB_ACCOUNT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLIENT_TB_ACCOUNT_ID_ACCOUNT",
                table: "TB_CLIENT");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLIENT_TB_ACCOUNT_ID_ACCOUNT",
                table: "TB_CLIENT",
                column: "ID_ACCOUNT",
                principalTable: "TB_ACCOUNT",
                principalColumn: "ID");
        }
    }
}
