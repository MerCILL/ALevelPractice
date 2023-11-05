using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module4_HM4_EF2.Migrations
{
    /// <inheritdoc />
    public partial class RequiredChangesBreed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Breed",
                newName: "Breeds");

            migrationBuilder.RenameIndex(
                name: "IX_Breed_CategoryId",
                table: "Breeds",
                newName: "IX_Breeds_CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Breeds",
                newName: "Breed");

            migrationBuilder.RenameIndex(
                name: "IX_Breeds_CategoryId",
                table: "Breed",
                newName: "IX_Breed_CategoryId");
        }
    }
}
