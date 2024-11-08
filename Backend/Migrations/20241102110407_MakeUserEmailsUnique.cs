using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations;

/// <inheritdoc />
public partial class MakeUserEmailsUnique : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("4ab7c985-1a55-4866-90b3-fd9678d32203"),
            column: "PasswordHash",
            value: "AQAAAAIAAYagAAAAEJz8QMDXw6VP1AJBKAMQjia4X1TCRWoJwuWk/R3evW5hSZFOXiH3rgXYFGiCAEgILA==");

        migrationBuilder.CreateIndex(
            name: "IX_Users_EmailAddress",
            table: "Users",
            column: "EmailAddress",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_Users_EmailAddress",
            table: "Users");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("4ab7c985-1a55-4866-90b3-fd9678d32203"),
            column: "PasswordHash",
            value: "AQAAAAIAAYagAAAAEEAniPaMMireZV3jk7FdCf/asYqFK2XjJ2GLs0iTRj28wrNoKe38zsTj2uq84EaZOw==");
    }
}
