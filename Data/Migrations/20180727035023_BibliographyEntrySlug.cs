using Microsoft.EntityFrameworkCore.Migrations;

namespace socialarts.club.Data.Migrations
{
    public partial class BibliographyEntrySlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "BibliographyEntry",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "BibliographyEntry");
        }
    }
}
