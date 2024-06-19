using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConceptArchitect.BookManagement.EFRepository.Migrations
{
    /// <inheritdoc />
    public partial class Dropped_From_BookNote_Book : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookNotes_Books_BookId",
                table: "BookNotes");

            migrationBuilder.DropIndex(
                name: "IX_BookNotes_BookId",
                table: "BookNotes");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookNotes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "BookNotes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookNotes_BookId",
                table: "BookNotes",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookNotes_Books_BookId",
                table: "BookNotes",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
