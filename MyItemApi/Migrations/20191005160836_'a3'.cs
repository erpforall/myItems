using Microsoft.EntityFrameworkCore.Migrations;

namespace MyItemApi.Migrations
{
    public partial class a3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeNames_AttributeCategory_AttributeCategoryId",
                table: "AttributeNames");

            migrationBuilder.AlterColumn<int>(
                name: "AttributeCategoryId",
                table: "AttributeNames",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeNames_AttributeCategory_AttributeCategoryId",
                table: "AttributeNames",
                column: "AttributeCategoryId",
                principalTable: "AttributeCategory",
                principalColumn: "AttributeCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeNames_AttributeCategory_AttributeCategoryId",
                table: "AttributeNames");

            migrationBuilder.AlterColumn<int>(
                name: "AttributeCategoryId",
                table: "AttributeNames",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeNames_AttributeCategory_AttributeCategoryId",
                table: "AttributeNames",
                column: "AttributeCategoryId",
                principalTable: "AttributeCategory",
                principalColumn: "AttributeCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
