using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessibleLibrary.Migrations
{
    public partial class ChangeBookPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookImages_Books_BookId",
                table: "BookImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookLanguages_BookLanguageId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "Phone",
                table: "Books",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookLanguageId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BookImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookImages_Books_BookId",
                table: "BookImages",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookLanguages_BookLanguageId",
                table: "Books",
                column: "BookLanguageId",
                principalTable: "BookLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookImages_Books_BookId",
                table: "BookImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookLanguages_BookLanguageId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<int>(
                name: "BookLanguageId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BookImages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BookImages_Books_BookId",
                table: "BookImages",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookLanguages_BookLanguageId",
                table: "Books",
                column: "BookLanguageId",
                principalTable: "BookLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
