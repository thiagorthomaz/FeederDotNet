using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeederDotNet.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatasetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dataset",
                columns: table => new
                {
                    Uri = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dataset", x => x.Uri);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dataset");
        }
    }
}
