using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConceptArchitect.BookManagement.EFRepository.Migrations
{
    /// <inheritdoc />
    public partial class Added_BookShelf_Notes_Reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookShelfItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShelfItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookShelfItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookShelfItems_Members_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Members",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Members_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Members",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BookShelfItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookNotes_BookShelfItems_BookShelfItemId",
                        column: x => x.BookShelfItemId,
                        principalTable: "BookShelfItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookNotes_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookNotes_Members_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Members",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookNotes_BookId",
                table: "BookNotes",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookNotes_BookShelfItemId",
                table: "BookNotes",
                column: "BookShelfItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BookNotes_UserEmail",
                table: "BookNotes",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_BookShelfItems_BookId",
                table: "BookShelfItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookShelfItems_UserEmail",
                table: "BookShelfItems",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserEmail",
                table: "Reviews",
                column: "UserEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookNotes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "BookShelfItems");
        }
    }
}
