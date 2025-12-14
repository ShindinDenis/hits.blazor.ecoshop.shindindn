using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcoShop.Migrations
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CustomerAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerPhone = table.Column<string>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Дом и быт" },
                    { 2, "Красота и уход" },
                    { 3, "Здоровое питание" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 2, "100% биоразлагаемая ручка. Угольное напыление.", "https://placehold.co/600x400/81c784/ffffff?text=Бамбуковая+щетка", "Бамбуковая зубная щетка", 250m },
                    { 2, 2, "Экономичный и натуральный. Хватает на 3 месяца.", "https://placehold.co/600x400/ba68c8/ffffff?text=Твердый+шампунь", "Твердый шампунь", 380m },
                    { 3, 2, "Кристалл алунит. Без запаха и пятен.", "https://placehold.co/600x400/f8bbd0/ffffff?text=Дезодорант", "Натуральный дезодорант", 550m },
                    { 4, 2, "Для мягкого очищения лица. 100% растительный.", "https://placehold.co/600x400/26a69a/ffffff?text=Спонж", "Спонж Конняку", 300m },
                    { 5, 1, "Прочный органический хлопок. Выдерживает 15 кг.", "https://placehold.co/600x400/d7ccc8/5d4037?text=Эко-сумка", "Эко-сумка (Шоппер)", 500m },
                    { 6, 1, "Стильная, держит тепло 2 часа. Стекло и пробка.", "https://placehold.co/600x400/4fc3f7/ffffff?text=Термокружка", "Термокружка KeepCup", 1200m },
                    { 7, 1, "Набор 4 шт + ершик. Нержавеющая сталь.", "https://placehold.co/600x400/cfd8dc/455a64?text=Трубочки", "Металлические трубочки", 600m },
                    { 8, 1, "Замена пищевой пленке. Хлопок + пчелиный воск.", "https://placehold.co/600x400/ffecb3/ff6f00?text=Салфетки", "Восковые салфетки", 800m },
                    { 9, 3, "Запеченные мюсли с орехами и медом. Без сахара.", "https://placehold.co/600x400/ffcc80/e65100?text=Гранола", "Гранола домашняя", 450m },
                    { 10, 3, "Японский зеленый чай высшего сорта. Бодрит.", "https://placehold.co/600x400/66bb6a/ffffff?text=Матча", "Чай Матча (Matcha)", 990m },
                    { 11, 3, "Extra Virgin. Для жарки и косметических целей.", "https://placehold.co/600x400/ffffff/333333?text=Масло", "Кокосовое масло", 700m },
                    { 12, 3, "Нейлоновый мешочек для фильтрации молока.", "https://placehold.co/600x400/e0e0e0/333333?text=Мешочек", "Мешочек для орехового молока", 350m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
