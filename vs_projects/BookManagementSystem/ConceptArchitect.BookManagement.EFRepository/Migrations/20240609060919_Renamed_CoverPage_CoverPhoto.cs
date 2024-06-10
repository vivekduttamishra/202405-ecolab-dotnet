using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConceptArchitect.BookManagement.EFRepository.Migrations
{
    /// <inheritdoc />
    public partial class Renamed_CoverPage_CoverPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverPage",
                table: "Books",
                newName: "CoverPhoto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverPhoto",
                table: "Books",
                newName: "CoverPage");
        }
    }
}
