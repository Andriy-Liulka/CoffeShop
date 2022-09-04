using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsMilk = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BonusesSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percent = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volumes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCoffees",
                columns: table => new
                {
                    DiscountId = table.Column<long>(type: "bigint", nullable: false),
                    CoffeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCoffees", x => new { x.CoffeeId, x.DiscountId });
                    table.ForeignKey(
                        name: "FK_DiscountCoffees_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountCoffees_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    AvatarImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bonuses = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonusCoffees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BonusPrice = table.Column<long>(type: "bigint", nullable: false),
                    CoffeeId = table.Column<long>(type: "bigint", nullable: false),
                    VolumeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusCoffees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonusCoffees_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BonusCoffees_Volumes_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationDate = table.Column<DateTimeOffset>(type: "DATETIMEOFFSET(4)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "DECIMAL(20,10)", nullable: false),
                    TotalBonusesSize = table.Column<long>(type: "bigint", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    DeliveryWay = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderVolumeCoffees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    VolumeId = table.Column<long>(type: "bigint", nullable: false),
                    CoffeetId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(15,7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderVolumeCoffees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderVolumeCoffees_Coffees_CoffeetId",
                        column: x => x.CoffeetId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderVolumeCoffees_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderVolumeCoffees_Volumes_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coffees",
                columns: new[] { "Id", "BonusesSize", "IsMilk", "Name", "Provider" },
                values: new object[,]
                {
                    { 1L, 0L, 1, "Latte", "United States" },
                    { 2L, 10L, 0, "Americano", "North USA" },
                    { 3L, 6L, 1, "Capuchino", "Italia" },
                    { 4L, 15L, 0, "Ekspresso", "USA" },
                    { 5L, 20L, 1, "Flat-White", "Australia" },
                    { 6L, 30L, 0, "Mokachino", "USA" },
                    { 7L, 3L, 0, "Black coffee", "Efiopia" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Percent" },
                values: new object[,]
                {
                    { 1L, 40f },
                    { 2L, 30f },
                    { 3L, 65f },
                    { 4L, 24f },
                    { 5L, 37f }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Admin" },
                    { 2L, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Volumes",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 1L, 200, "Small" },
                    { 2L, 250, "Small" },
                    { 3L, 300, "Average" },
                    { 4L, 350, "Average" },
                    { 5L, 450, "Large" },
                    { 6L, 500, "Large" }
                });

            migrationBuilder.InsertData(
                table: "BonusCoffees",
                columns: new[] { "Id", "BonusPrice", "CoffeeId", "VolumeId" },
                values: new object[,]
                {
                    { 1L, 200L, 1L, 1L },
                    { 2L, 250L, 7L, 3L },
                    { 3L, 310L, 4L, 5L },
                    { 4L, 435L, 2L, 4L },
                    { 5L, 500L, 7L, 6L }
                });

            migrationBuilder.InsertData(
                table: "DiscountCoffees",
                columns: new[] { "CoffeeId", "DiscountId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 5L },
                    { 3L, 3L },
                    { 5L, 4L },
                    { 6L, 2L },
                    { 7L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BonusCoffees_CoffeeId",
                table: "BonusCoffees",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusCoffees_VolumeId",
                table: "BonusCoffees",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCoffees_DiscountId",
                table: "DiscountCoffees",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderVolumeCoffees_CoffeetId",
                table: "OrderVolumeCoffees",
                column: "CoffeetId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderVolumeCoffees_OrderId",
                table: "OrderVolumeCoffees",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderVolumeCoffees_VolumeId",
                table: "OrderVolumeCoffees",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonusCoffees");

            migrationBuilder.DropTable(
                name: "DiscountCoffees");

            migrationBuilder.DropTable(
                name: "OrderVolumeCoffees");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Coffees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Volumes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
