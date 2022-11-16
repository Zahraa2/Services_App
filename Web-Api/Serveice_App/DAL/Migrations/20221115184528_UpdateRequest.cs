using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class UpdateRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoreDetails",
                table: "Requests",
                newName: "Img");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Requests",
                newName: "ProviderStartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CustmoerSendDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestType",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustmoerSendDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestType",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "ProviderStartDate",
                table: "Requests",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Img",
                table: "Requests",
                newName: "MoreDetails");
        }
    }
}
