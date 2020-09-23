using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merchants.Web.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchants_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Merchants_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("eef7fb91-f2a4-42d2-9c7d-e30ab7cdfd44"), "Australia" },
                    { new Guid("2288f577-e965-4727-bd28-7a5cf2247f5d"), "New Zealand" },
                    { new Guid("a81f1301-903b-45ca-840c-533077523af5"), "India" },
                    { new Guid("4c0907f9-2c5f-4d3e-bc5d-ce5c49dc66b8"), "USA" },
                    { new Guid("def5f724-7794-4299-810c-0c5b2d89c7dd"), "Great Britain" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("038e3b65-ffdf-4f23-8767-ee2f079eb160"), "AUD" },
                    { new Guid("aac9e06c-aa9d-4e6a-9a1a-ef7189daf38f"), "NZD" },
                    { new Guid("590e1142-81f9-4691-a379-c6ff97f21bbc"), "INR" },
                    { new Guid("a3fced19-470b-43f3-913f-b77e1abc3ae7"), "USD" },
                    { new Guid("d1577738-f7e4-4565-9f1d-901daf6669b6"), "GBP" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_CountryId",
                table: "Merchants",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_CurrencyId",
                table: "Merchants",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
