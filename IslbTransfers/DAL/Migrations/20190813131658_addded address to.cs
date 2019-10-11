using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class adddedaddressto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressTo",
                table: "ExchangeTransactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressTo",
                table: "ExchangeTransactions");
        }
    }
}
