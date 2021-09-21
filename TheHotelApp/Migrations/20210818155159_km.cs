using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheHotelApp.Migrations
{
    public partial class km : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerCity",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Guests",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TotalFee",
                table: "Bookings",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Paid",
                table: "Bookings",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CustomerPhone",
                table: "Bookings",
                newName: "AgreementNumber");

            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "Bookings",
                newName: "RentalDate");

            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "Bookings",
                newName: "ApplicationDate");

            migrationBuilder.AddColumn<string>(
                name: "ChiefGuests",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentalPeriod",
                table: "Bookings",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomTypesID",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeID",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: false),
                    CustomerName = table.Column<string>(nullable: false),
                    CustomerPhone = table.Column<string>(nullable: false),
                    OtherAddress = table.Column<string>(nullable: true),
                    OtherContact = table.Column<string>(nullable: true),
                    PrimaryAddress = table.Column<string>(nullable: false),
                    PrimaryContact = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerID",
                table: "Bookings",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomTypesID",
                table: "Bookings",
                column: "RoomTypesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerID",
                table: "Bookings",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_RoomTypes_RoomTypesID",
                table: "Bookings",
                column: "RoomTypesID",
                principalTable: "RoomTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_RoomTypes_RoomTypesID",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CustomerID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomTypesID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ChiefGuests",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RentalPeriod",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomTypesID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Bookings",
                newName: "Paid");

            migrationBuilder.RenameColumn(
                name: "RentalDate",
                table: "Bookings",
                newName: "CheckOut");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Bookings",
                newName: "TotalFee");

            migrationBuilder.RenameColumn(
                name: "ApplicationDate",
                table: "Bookings",
                newName: "CheckIn");

            migrationBuilder.RenameColumn(
                name: "AgreementNumber",
                table: "Bookings",
                newName: "CustomerPhone");

            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "Bookings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerCity",
                table: "Bookings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Bookings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Bookings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Guests",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
