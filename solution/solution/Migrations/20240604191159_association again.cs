using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace solution.Migrations
{
    /// <inheritdoc />
    public partial class associationagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_ProductId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesCategoryId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "PK_category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PK_role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PK_role);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    PK_account = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_role = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.PK_account);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_FK_role",
                        column: x => x.FK_role,
                        principalTable: "Roles",
                        principalColumn: "PK_role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_RoleId",
                table: "Products",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FK_role",
                table: "Accounts",
                column: "FK_role");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsProductId",
                table: "CategoryProduct",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Roles_RoleId",
                table: "Products",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "PK_role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Roles_RoleId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Products_RoleId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductId",
                table: "Categories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_ProductId",
                table: "Categories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "PK_product");
        }
    }
}
