using Microsoft.EntityFrameworkCore.Migrations;

namespace MyItemApi.Migrations
{
    public partial class a4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeNames_AttributeCategory_AttributeCategoryId",
                table: "AttributeNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttributeCategory",
                table: "AttributeCategory");

            migrationBuilder.RenameTable(
                name: "AttributeCategory",
                newName: "AttributeCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttributeCategories",
                table: "AttributeCategories",
                column: "AttributeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeNames_AttributeCategories_AttributeCategoryId",
                table: "AttributeNames",
                column: "AttributeCategoryId",
                principalTable: "AttributeCategories",
                principalColumn: "AttributeCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeNames_AttributeCategories_AttributeCategoryId",
                table: "AttributeNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttributeCategories",
                table: "AttributeCategories");

            migrationBuilder.RenameTable(
                name: "AttributeCategories",
                newName: "AttributeCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttributeCategory",
                table: "AttributeCategory",
                column: "AttributeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeNames_AttributeCategory_AttributeCategoryId",
                table: "AttributeNames",
                column: "AttributeCategoryId",
                principalTable: "AttributeCategory",
                principalColumn: "AttributeCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
