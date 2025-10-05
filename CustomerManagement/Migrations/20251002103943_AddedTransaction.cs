using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddedTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WhatsAppNumeber",
                table: "Customer",
                newName: "WhatsAppNumber");

            migrationBuilder.RenameColumn(
                name: "Refrence",
                table: "Customer",
                newName: "Reference");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Service",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Service",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CustomerService",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CustomerService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Customer",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CustomerService");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CustomerService");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "WhatsAppNumber",
                table: "Customer",
                newName: "WhatsAppNumeber");

            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "Customer",
                newName: "Refrence");
        }
    }
}
