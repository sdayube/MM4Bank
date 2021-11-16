using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MM4Bank.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NR_ACCOUNT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VL_BALANCE = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ID_CLIENT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    DT_CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DT_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ST_ISACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ACCOUNT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLIENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NM_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NR_CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ID_ACCOUNT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    DS_ADRESS = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DS_PASSWORD = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DT_CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DT_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ST_ISACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CLIENT_TB_ACCOUNT_ID_ACCOUNT",
                        column: x => x.ID_ACCOUNT,
                        principalTable: "TB_ACCOUNT",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_TRANSACTION",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VL_VALUE = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ID_SOURCE_ACCOUNT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    ID_TARGET_ACCOUNT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    DS_TYPE = table.Column<int>(type: "int", nullable: false),
                    DT_CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DT_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ST_ISACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TRANSACTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_TRANSACTION_TB_ACCOUNT_ID_SOURCE_ACCOUNT",
                        column: x => x.ID_SOURCE_ACCOUNT,
                        principalTable: "TB_ACCOUNT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_TRANSACTION_TB_ACCOUNT_ID_TARGET_ACCOUNT",
                        column: x => x.ID_TARGET_ACCOUNT,
                        principalTable: "TB_ACCOUNT",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENT_ID_ACCOUNT",
                table: "TB_CLIENT",
                column: "ID_ACCOUNT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTION_ID_SOURCE_ACCOUNT",
                table: "TB_TRANSACTION",
                column: "ID_SOURCE_ACCOUNT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTION_ID_TARGET_ACCOUNT",
                table: "TB_TRANSACTION",
                column: "ID_TARGET_ACCOUNT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CLIENT");

            migrationBuilder.DropTable(
                name: "TB_TRANSACTION");

            migrationBuilder.DropTable(
                name: "TB_ACCOUNT");
        }
    }
}
