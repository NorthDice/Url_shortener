using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Url_shortener.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUrlServiceSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Urls",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Urls");
        }

    }
}
