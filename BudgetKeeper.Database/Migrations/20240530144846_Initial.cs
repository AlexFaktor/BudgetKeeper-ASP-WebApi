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
                    Comment = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24ce6296-851b-40a9-bde1-cac9d77b2ef3"), "Fine" },
                    { new Guid("37cba832-f797-49c8-85f2-6c5227098bf7"), "Gifts" },
                    { new Guid("3dd99611-4824-4e98-8224-0bd8534d563b"), "Unknown" },
                    { new Guid("7c979f16-a873-45f8-aa7c-1ba712e95494"), "Credit" },
                    { new Guid("99663bad-9b23-455a-b6d1-70925b9158d9"), "Software" },
                    { new Guid("9f30e76e-dbfb-4280-ae66-6450378f0fa6"), "Health" },
                    { new Guid("c66ae73f-e3d9-4c67-8f78-3ef6b0e76bf9"), "Taxes" },
                    { new Guid("c983e8fa-08d1-4095-873e-e9131a50b0ae"), "Activities" },
                    { new Guid("ced59dfe-4571-4096-b006-3717a1ef13a0"), "Products" },
                    { new Guid("d73b6844-dc87-46e3-9d33-0d9b4d84e483"), "Salary" },
                    { new Guid("f4b67b31-58fd-4784-9528-305df36ebe64"), "Preservation" }
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
