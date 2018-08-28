using Microsoft.EntityFrameworkCore.Migrations;

namespace socialarts.club.Data.Migrations
{
    public partial class addtemplateurlpath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TemplateUrlPath",
                table: "ToolsDocument",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateUrlPath",
                table: "ToolsDocument");
        }
    }
}
