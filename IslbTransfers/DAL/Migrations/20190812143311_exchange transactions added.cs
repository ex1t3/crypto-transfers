using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class exchangetransactionsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeTransactions",
                columns: table => new
                {
                    UniqueId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ExternalServiceId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    BlockchainFee = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    TotalAmount = table.Column<string>(nullable: true),
                    GivenAmount = table.Column<string>(nullable: true),
                    ReceivedAmount = table.Column<string>(nullable: true),
                    Stock = table.Column<string>(nullable: true),
                    Rate = table.Column<string>(nullable: true),
                    Commission = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeTransactions", x => x.UniqueId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeTransactions");
        }
    }
}
