using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConceptArchitect.BookManagement.EFRepository.Migrations
{
    /// <inheritdoc />
    public partial class Added_Author_DeathDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeathDate",
                table: "Authors",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeathDate",
                table: "Authors");
        }
    }
}
