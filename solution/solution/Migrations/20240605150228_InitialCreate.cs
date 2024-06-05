using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace solution.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "PK_category", "name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "PK_product", "depth", "height", "name", "weight", "width", "RoleId" },
                values: new object[,]
                {
                    { 1, 25.0, 2.0, "Laptop", 2.5, 35.0, null },
                    { 2, 20.0, 2.0, "Book", 0.5, 15.0, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PK_role", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "PK_account", "email", "first_name", "last_name", "phone", "FK_role" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe", "123456789", 1 },
                    { 2, "jane.smith@example.com", "Jane", "Smith", "987654321", 2 }
                });

            migrationBuilder.InsertData(
                table: "Shopping_Carts",
                columns: new[] { "FK_Account", "FK_Product", "amount" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shopping_Carts",
                keyColumns: new[] { "FK_Account", "FK_Product" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Shopping_Carts",
                keyColumns: new[] { "FK_Account", "FK_Product" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 2);
        }
    }
}
