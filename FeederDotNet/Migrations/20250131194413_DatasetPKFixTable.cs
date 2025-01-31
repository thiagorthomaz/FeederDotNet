using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeederDotNet.Migrations
{
    /// <inheritdoc />
    public partial class DatasetPKFixTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dataset",
                table: "Dataset");

            migrationBuilder.DropColumn(
                name: "Uri",
                table: "Dataset");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Dataset",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dataset",
                table: "Dataset",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dataset",
                table: "Dataset");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Dataset");

            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "Dataset",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dataset",
                table: "Dataset",
                column: "Uri");
        }
    }
}
