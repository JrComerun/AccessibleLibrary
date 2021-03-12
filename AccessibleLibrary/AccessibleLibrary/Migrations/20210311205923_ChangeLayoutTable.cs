using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessibleLibrary.Migrations
{
    public partial class ChangeLayoutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Footer",
                table: "Layout",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Footer",
                table: "Layout");
        }
    }
}
