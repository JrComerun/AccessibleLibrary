using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessibleLibrary.Migrations
{
    public partial class AddSubscribeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubScribes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubScribes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookSubScribes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    SubScribeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSubScribes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookSubScribes_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSubScribes_SubScribes_SubScribeId",
                        column: x => x.SubScribeId,
                        principalTable: "SubScribes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookSubScribes_BookId",
                table: "BookSubScribes",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSubScribes_SubScribeId",
                table: "BookSubScribes",
                column: "SubScribeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookSubScribes");

            migrationBuilder.DropTable(
                name: "SubScribes");
        }
    }
}
