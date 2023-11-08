using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module4_HM4_EF2.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedEntitiesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");
        }
    }
}
