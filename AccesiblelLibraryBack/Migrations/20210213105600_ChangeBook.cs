using Microsoft.EntityFrameworkCore.Migrations;

namespace AccesiblelLibraryBack.Migrations
{
    public partial class ChangeBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Books");
        }
    }
}
