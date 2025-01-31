using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeederDotNet.Migrations
{
    /// <inheritdoc />
    public partial class DatasetAddedUrlField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Dataset",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Dataset");
        }
    }
}
