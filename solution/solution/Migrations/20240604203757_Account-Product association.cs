using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace solution.Migrations
{
    /// <inheritdoc />
    public partial class AccountProductassociation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shopping_Carts",
                columns: table => new
                {
                    FK_Account = table.Column<int>(type: "int", nullable: false),
                    FK_Product = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Carts", x => new { x.FK_Account, x.FK_Product });
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Accounts_FK_Account",
                        column: x => x.FK_Account,
                        principalTable: "Accounts",
                        principalColumn: "PK_account",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Products_FK_Product",
                        column: x => x.FK_Product,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Carts_FK_Product",
                table: "Shopping_Carts",
                column: "FK_Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shopping_Carts");
        }
    }
}
