using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class posts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_Provider_Providerid",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "Providerid",
                table: "posts",
                newName: "ProviderID");

            migrationBuilder.RenameIndex(
                name: "IX_posts_Providerid",
                table: "posts",
                newName: "IX_posts_ProviderID");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProviderID",
                table: "posts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_Provider_ProviderID",
                table: "posts",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_Provider_ProviderID",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "ProviderID",
                table: "posts",
                newName: "Providerid");

            migrationBuilder.RenameIndex(
                name: "IX_posts_ProviderID",
                table: "posts",
                newName: "IX_posts_Providerid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Providerid",
                table: "posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_Provider_Providerid",
                table: "posts",
                column: "Providerid",
                principalTable: "Provider",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
