using Microsoft.EntityFrameworkCore.Migrations;

namespace MM4Bank.Infra.Data.Migrations
{
    public partial class LastTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TRANSACTION_TB_ACCOUNT_ID_SOURCE_ACCOUNT",
                table: "TB_TRANSACTION");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_TRANSACTION_TB_ACCOUNT_ID_TARGET_ACCOUNT",
                table: "TB_TRANSACTION");

            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTION_ID_SOURCE_ACCOUNT",
                table: "TB_TRANSACTION");

            migrationBuilder.DropIndex(
                name: "IX_TB_TRANSACTION_ID_TARGET_ACCOUNT",
                table: "TB_TRANSACTION");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTION_ID_SOURCE_ACCOUNT",
                table: "TB_TRANSACTION",
                column: "ID_SOURCE_ACCOUNT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTION_ID_TARGET_ACCOUNT",
                table: "TB_TRANSACTION",
                column: "ID_TARGET_ACCOUNT");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TRANSACTION_TB_ACCOUNT_ID_SOURCE_ACCOUNT",
                table: "TB_TRANSACTION",
                column: "ID_SOURCE_ACCOUNT",
                principalTable: "TB_ACCOUNT",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TRANSACTION_TB_ACCOUNT_ID_TARGET_ACCOUNT",
                table: "TB_TRANSACTION",
                column: "ID_TARGET_ACCOUNT",
                principalTable: "TB_ACCOUNT",
                principalColumn: "ID");
        }
    }
}
