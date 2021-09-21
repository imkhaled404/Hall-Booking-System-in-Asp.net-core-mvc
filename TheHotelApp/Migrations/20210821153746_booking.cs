using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheHotelApp.Migrations
{
    public partial class booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ApplicationId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "OtherRequests",
                table: "Bookings",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Bookings",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "Bookings",
                newName: "SpeciaGuests");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Bookings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpeciaGuests",
                table: "Bookings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicantName",
                table: "Bookings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentID",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<string>(nullable: false),
                    PaymentType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ApplicationUserId",
                table: "Bookings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PaymentID",
                table: "Bookings",
                column: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                table: "Bookings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Payments_PaymentID",
                table: "Bookings",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Payments_PaymentID",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ApplicationUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PaymentID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ApplicantName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Bookings",
                newName: "OtherRequests");

            migrationBuilder.RenameColumn(
                name: "SpeciaGuests",
                table: "Bookings",
                newName: "ApplicationId");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Bookings",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Bookings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationId",
                table: "Bookings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ApplicationId",
                table: "Bookings",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationId",
                table: "Bookings",
                column: "ApplicationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
