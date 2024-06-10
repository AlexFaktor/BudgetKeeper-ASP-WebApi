using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetKeeper.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3fd3c143-9f68-4cf0-b96a-e81d9766caa5"), "Credit" },
                    { new Guid("52b86fab-3c94-4c2b-b90d-b967f1bcabcb"), "Fine" },
                    { new Guid("61487c48-8d66-4913-a1ed-1b996dff5be8"), "Preservation" },
                    { new Guid("7e10ea46-29dc-4e05-8626-5a94291f2ea1"), "Unknown" },
                    { new Guid("7fd2297f-6bfb-4946-a8e4-8bd05818d7f8"), "Gifts" },
                    { new Guid("83506bb3-b914-4a76-9e1c-b5798e148d1f"), "Health" },
                    { new Guid("9248ed7e-c127-4903-b32d-f0d3ff83ec31"), "Salary" },
                    { new Guid("b96de06f-7af6-4cb4-9c6e-eed6253d612c"), "Software" },
                    { new Guid("c49be0ad-65e4-4d31-9e58-5e68b622a2e6"), "Products" },
                    { new Guid("cf7281a2-7912-4e25-9f87-7657b1e333e6"), "Taxes" },
                    { new Guid("e12882ec-9c4a-403a-9886-c1c639e0ef0e"), "Activities" }
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
