using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagement.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "CustomerService",
                newName: "CustomerPrice");

            migrationBuilder.AddColumn<string>(
                name: "MinimumPriceList",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "WhatsAppNumeber",
                table: "Customer",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumPriceList",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "WhatsAppNumeber",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "CustomerPrice",
                table: "CustomerService",
                newName: "Price");
        }
    }
}
