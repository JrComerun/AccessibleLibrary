using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessibleLibrary.Migrations
{
    public partial class ChangeRelationSitesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "RelationSites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "RelationSites");
        }
    }
}
