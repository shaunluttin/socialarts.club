using Microsoft.EntityFrameworkCore.Migrations;

namespace socialarts.club.Data.Migrations
{
    public partial class webdocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RetrievedFrom",
                table: "BibliographyEntry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "BibliographyEntry",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetrievedFrom",
                table: "BibliographyEntry");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "BibliographyEntry");
        }
    }
}
