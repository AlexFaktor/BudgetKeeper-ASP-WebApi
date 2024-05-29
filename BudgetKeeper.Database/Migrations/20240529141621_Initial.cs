using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetKeeper.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Income = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("035698cd-aade-49a9-9193-6076c659b701"), "Unknown" },
                    { new Guid("157e8737-e7b3-42a1-bb2c-3332f0767f52"), "Products" },
                    { new Guid("1a76be85-d3ab-4901-bb73-0959b5f70f9d"), "Activities" },
                    { new Guid("1c8a1709-26a1-49fb-aee0-77bec0413c50"), "Credit" },
                    { new Guid("30e1211d-640d-40d0-84ab-b33736b2b998"), "Fine" },
                    { new Guid("96abf42c-d4ce-4559-8769-e4aeb3924669"), "Preservation" },
                    { new Guid("9a60b64d-25eb-42df-ab0d-be39b82c9120"), "Salary" },
                    { new Guid("9d516213-36d0-49ac-9e44-dda8001e2bd1"), "Taxes" },
                    { new Guid("9d6a303a-5dd8-4f0c-af55-9fd13aed0dab"), "Gifts" },
                    { new Guid("d12b01b0-21a8-4e27-8e4b-dd49a8e7c238"), "Health" },
                    { new Guid("eb79826e-f7f6-44b3-877b-668506eb10ed"), "Software" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
