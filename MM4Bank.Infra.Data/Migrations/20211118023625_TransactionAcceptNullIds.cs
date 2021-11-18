using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MM4Bank.Infra.Data.Migrations
{
    public partial class TransactionAcceptNullIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID_TARGET_ACCOUNT",
                table: "TB_TRANSACTION",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_SOURCE_ACCOUNT",
                table: "TB_TRANSACTION",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID_TARGET_ACCOUNT",
                table: "TB_TRANSACTION",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_SOURCE_ACCOUNT",
                table: "TB_TRANSACTION",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
