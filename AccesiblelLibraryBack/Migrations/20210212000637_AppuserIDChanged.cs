using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccesiblelLibraryBack.Migrations
{
    public partial class AppuserIDChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_AspNetUsers_AppUserId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookLanguage_BookLanguageId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookDetail_Book_BookId",
                table: "BookDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookImage_Book_BookId",
                table: "BookImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_Book_BookLanguageId",
                table: "Books",
                newName: "IX_Books_BookLanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AppUserId",
                table: "Books",
                newName: "IX_Books_AppUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteTime",
                table: "BookDetail",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteTime",
                table: "Books",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppUserBook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserBook_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBook_AppUserId",
                table: "AppUserBook",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserBook_BookId",
                table: "AppUserBook",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetail_Books_BookId",
                table: "BookDetail",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookImage_Books_BookId",
                table: "BookImage",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_AppUserId",
                table: "Books",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookLanguage_BookLanguageId",
                table: "Books",
                column: "BookLanguageId",
                principalTable: "BookLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetail_Books_BookId",
                table: "BookDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookImage_Books_BookId",
                table: "BookImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_AppUserId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookLanguage_BookLanguageId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "AppUserBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_Books_BookLanguageId",
                table: "Book",
                newName: "IX_Book_BookLanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AppUserId",
                table: "Book",
                newName: "IX_Book_AppUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteTime",
                table: "BookDetail",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteTime",
                table: "Book",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_AspNetUsers_AppUserId",
                table: "Book",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookLanguage_BookLanguageId",
                table: "Book",
                column: "BookLanguageId",
                principalTable: "BookLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetail_Book_BookId",
                table: "BookDetail",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookImage_Book_BookId",
                table: "BookImage",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
