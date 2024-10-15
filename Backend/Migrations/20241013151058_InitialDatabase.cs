using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations;

/// <inheritdoc />
public partial class InitialDatabase : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Ingredients",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                ImageUrl = table.Column<string>(type: "text", nullable: false),
                Stock = table.Column<double>(type: "double precision", nullable: false),
                MaxStock = table.Column<double>(type: "double precision", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Ingredients", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                Description = table.Column<string>(type: "text", nullable: false),
                Price = table.Column<decimal>(type: "numeric", nullable: false),
                ImageUrl = table.Column<string>(type: "text", nullable: false),
                Stock = table.Column<int>(type: "integer", nullable: false),
                Reserved = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EmailAddress = table.Column<string>(type: "text", nullable: false),
                PasswordHash = table.Column<string>(type: "text", nullable: false),
                LastSeen = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Registered = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Role = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ProductIngredients",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                Quantity = table.Column<double>(type: "double precision", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProductIngredients", x => x.Id);
                table.ForeignKey(
                    name: "FK_ProductIngredients_Ingredients_IngredientId",
                    column: x => x.IngredientId,
                    principalTable: "Ingredients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ProductIngredients_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: false),
                OrderPlaced = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                OrderPaid = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                OrderShipped = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                OrderReceived = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                OrderRefunded = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                Discount = table.Column<decimal>(type: "numeric", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.Id);
                table.ForeignKey(
                    name: "FK_Orders_Users_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "OrderItems",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                Quantity = table.Column<int>(type: "integer", nullable: false),
                Price = table.Column<decimal>(type: "numeric", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrderItems", x => x.Id);
                table.ForeignKey(
                    name: "FK_OrderItems_Orders_OrderId",
                    column: x => x.OrderId,
                    principalTable: "Orders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_OrderItems_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "EmailAddress", "LastSeen", "PasswordHash", "Registered", "Role" },
            values: new object[] { new Guid("4ab7c985-1a55-4866-90b3-fd9678d32203"), "admin@bellacroissant.fr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEEAniPaMMireZV3jk7FdCf/asYqFK2XjJ2GLs0iTRj28wrNoKe38zsTj2uq84EaZOw==", new DateTime(2024, 10, 13, 15, 10, 57, 968, DateTimeKind.Utc).AddTicks(9422), 1 });

        migrationBuilder.CreateIndex(
            name: "IX_OrderItems_OrderId",
            table: "OrderItems",
            column: "OrderId");

        migrationBuilder.CreateIndex(
            name: "IX_OrderItems_ProductId",
            table: "OrderItems",
            column: "ProductId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_CustomerId",
            table: "Orders",
            column: "CustomerId");

        migrationBuilder.CreateIndex(
            name: "IX_ProductIngredients_IngredientId_ProductId",
            table: "ProductIngredients",
            columns: new[] { "IngredientId", "ProductId" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_ProductIngredients_ProductId",
            table: "ProductIngredients",
            column: "ProductId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "OrderItems");

        migrationBuilder.DropTable(
            name: "ProductIngredients");

        migrationBuilder.DropTable(
            name: "Orders");

        migrationBuilder.DropTable(
            name: "Ingredients");

        migrationBuilder.DropTable(
            name: "Products");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
