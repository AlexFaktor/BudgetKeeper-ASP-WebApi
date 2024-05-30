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
                    { new Guid("1bc72cc8-384b-4b2a-a3f5-16d1e6b23543"), "Unknown" },
                    { new Guid("52756aa3-c18a-4b22-920b-b9876812bc33"), "Credit" },
                    { new Guid("541ce086-51aa-4058-9207-9c10be773757"), "Gifts" },
                    { new Guid("6eececdd-b7f8-41a5-9968-714d67b78a80"), "Taxes" },
                    { new Guid("7d062311-f7be-4fa9-b0cd-adebe8b6ddb9"), "Fine" },
                    { new Guid("8f812365-b6d9-425c-b690-6e4f4032de85"), "Preservation" },
                    { new Guid("992f3450-832c-40ed-89ba-4389b7db8868"), "Software" },
                    { new Guid("9cd17f10-7bf2-4a7a-98de-5615c6d74dcf"), "Products" },
                    { new Guid("ccff22a7-cf17-4ca2-94b0-4f432c7833f8"), "Salary" },
                    { new Guid("dc231561-697a-45ad-8348-9ae673a28ce2"), "Health" },
                    { new Guid("ee618fab-3ca9-4821-a714-1bee3a895a20"), "Activities" }
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
