using Microsoft.EntityFrameworkCore.Migrations;

namespace AccesiblelLibraryBack.Migrations
{
    public partial class ChangeBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_AspNetUsers_AppUserId1",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AppUserId1",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Book",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AppUserId",
                table: "Book",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_AspNetUsers_AppUserId",
                table: "Book",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_AspNetUsers_AppUserId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AppUserId",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Book",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Book",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AppUserId1",
                table: "Book",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_AspNetUsers_AppUserId1",
                table: "Book",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
