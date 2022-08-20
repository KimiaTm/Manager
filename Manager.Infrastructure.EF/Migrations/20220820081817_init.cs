using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infrastructure.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    FactorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tedad = table.Column<int>(type: "INT", nullable: false),
                    SellTime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Costomer = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Factor_StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.FactorId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Mojodi = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Factor_StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factor_Store",
                columns: table => new
                {
                    Factor_StoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(nullable: true),
                    FactorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factor_Store", x => x.Factor_StoreId);
                    table.ForeignKey(
                        name: "FK_Factor_Store_Factors_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Factors",
                        principalColumn: "FactorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factor_Store_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Brand = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    FactorId = table.Column<int>(nullable: false),
                    FactorId1 = table.Column<int>(nullable: true),
                    StoreId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Factors_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Factors",
                        principalColumn: "FactorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Factors_FactorId1",
                        column: x => x.FactorId1,
                        principalTable: "Factors",
                        principalColumn: "FactorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId1",
                        column: x => x.StoreId1,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factor_Store_FactorId",
                table: "Factor_Store",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Factor_Store_StoreId",
                table: "Factor_Store",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FactorId",
                table: "Products",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FactorId1",
                table: "Products",
                column: "FactorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId1",
                table: "Products",
                column: "StoreId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factor_Store");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
