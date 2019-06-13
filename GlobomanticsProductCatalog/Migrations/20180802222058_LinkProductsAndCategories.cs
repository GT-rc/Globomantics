using Microsoft.EntityFrameworkCore.Migrations;

namespace GlobomanticsProductCatalog.Migrations
{
    public partial class LinkProductsAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CateogryId",
                table: "Products",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CateogryId",
                table: "Products",
                column: "CateogryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CateogryId",
                table: "Products",
                column: "CateogryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CateogryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CateogryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CateogryId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");
        }
    }
}
