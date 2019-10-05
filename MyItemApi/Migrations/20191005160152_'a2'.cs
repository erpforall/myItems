using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyItemApi.Migrations
{
    public partial class a2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttributeCategoryId",
                table: "AttributeNames",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AttributeCategory",
                columns: table => new
                {
                    AttributeCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeCategory", x => x.AttributeCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeNames_AttributeCategoryId",
                table: "AttributeNames",
                column: "AttributeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeNames_AttributeCategory_AttributeCategoryId",
                table: "AttributeNames",
                column: "AttributeCategoryId",
                principalTable: "AttributeCategory",
                principalColumn: "AttributeCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeNames_AttributeCategory_AttributeCategoryId",
                table: "AttributeNames");

            migrationBuilder.DropTable(
                name: "AttributeCategory");

            migrationBuilder.DropIndex(
                name: "IX_AttributeNames_AttributeCategoryId",
                table: "AttributeNames");

            migrationBuilder.DropColumn(
                name: "AttributeCategoryId",
                table: "AttributeNames");
        }
    }
}
