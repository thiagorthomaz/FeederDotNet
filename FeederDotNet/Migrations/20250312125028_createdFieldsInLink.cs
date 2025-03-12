using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeederDotNet.Migrations
{
    /// <inheritdoc />
    public partial class createdFieldsInLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CrawledAt",
                table: "Link",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Link",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivatedAt",
                table: "Link",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "InactivatedAt",
                table: "Link");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CrawledAt",
                table: "Link",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
