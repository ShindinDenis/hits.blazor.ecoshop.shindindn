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
                    { 1, 2, "100% биоразлагаемая ручка.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyM4MWM3ODQnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyNmZmZmZmYnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0JHQsNC80LHRg9C60L7QstCw0Y8g0YnQtdGC0LrQsAogICAgICAgICAgICAgICAgICAgIDwvdGV4dD4KICAgICAgICAgICAgICAgIDwvc3ZnPg==", "Бамбуковая зубная щетка", 250m },
                    { 2, 2, "Экономичный и натуральный.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyNiYTY4YzgnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyNmZmZmZmYnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0KLQstC10YDQtNGL0Lkg0YjQsNC80L/Rg9C90YwKICAgICAgICAgICAgICAgICAgICA8L3RleHQ+CiAgICAgICAgICAgICAgICA8L3N2Zz4=", "Твердый шампунь", 380m },
                    { 3, 2, "Кристалл алунит. Без запаха.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyNmOGJiZDAnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyMzMzMnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0JTQtdC30L7QtNC+0YDQsNC90YIKICAgICAgICAgICAgICAgICAgICA8L3RleHQ+CiAgICAgICAgICAgICAgICA8L3N2Zz4=", "Натуральный дезодорант", 550m },
                    { 4, 2, "100% растительный.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyMyNmE2OWEnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyNmZmZmZmYnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0KHQv9C+0L3QtgogICAgICAgICAgICAgICAgICAgIDwvdGV4dD4KICAgICAgICAgICAgICAgIDwvc3ZnPg==", "Спонж Конняку", 300m },
                    { 5, 1, "Прочный органический хлопок.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyNkN2NjYzgnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyM1ZDQwMzcnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0K3QutC+LdGB0YPQvNC60LAKICAgICAgICAgICAgICAgICAgICA8L3RleHQ+CiAgICAgICAgICAgICAgICA8L3N2Zz4=", "Эко-сумка (Шоппер)", 500m },
                    { 6, 1, "Стильная, держит тепло 2 часа.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyM0ZmMzZjcnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyNmZmZmZmYnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0KLQtdGA0LzQvtC60YDRg9C20LrQsAogICAgICAgICAgICAgICAgICAgIDwvdGV4dD4KICAgICAgICAgICAgICAgIDwvc3ZnPg==", "Термокружка KeepCup", 1200m },
                    { 7, 1, "Набор 4 шт + ершик.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyNjZmQ4ZGMnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyM0NTVhNjQnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0KLRgNGD0LHQvtGH0LrQuAogICAgICAgICAgICAgICAgICAgIDwvdGV4dD4KICAgICAgICAgICAgICAgIDwvc3ZnPg==", "Металлические трубочки", 600m },
                    { 8, 1, "Замена пищевой пленке.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyNmZmVjYjMnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyNmZjZmMDAnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0KHQsNC70YTQtdGC0LrQuAogICAgICAgICAgICAgICAgICAgIDwvdGV4dD4KICAgICAgICAgICAgICAgIDwvc3ZnPg==", "Восковые салфетки", 800m },
                    { 9, 3, "Запеченные мюсли с орехами.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyNmZmNjODAnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyNlNjUxMDAnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0JPRgNCw0L3QvtC70LAKICAgICAgICAgICAgICAgICAgICA8L3RleHQ+CiAgICAgICAgICAgICAgICA8L3N2Zz4=", "Гранола домашняя", 450m },
                    { 10, 3, "Японский зеленый чай.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyM2NmJiNmEnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyNmZmZmZmYnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0JzQsNGC0YfQsAogICAgICAgICAgICAgICAgICAgIDwvdGV4dD4KICAgICAgICAgICAgICAgIDwvc3ZnPg==", "Чай Матча (Matcha)", 990m },
                    { 11, 3, "Extra Virgin.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyNmZmZmZmYnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyMzMzMnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0JzQsNGB0LvQvgogICAgICAgICAgICAgICAgICAgIDwvdGV4dD4KICAgICAgICAgICAgICAgIDwvc3ZnPg==", "Кокосовое масло", 700m },
                    { 12, 3, "Нейлоновый мешочек.", "data:image/svg+xml;base64,CiAgICAgICAgICAgICAgICA8c3ZnIHdpZHRoPSc2MDAnIGhlaWdodD0nNDAwJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPgogICAgICAgICAgICAgICAgICAgIDxyZWN0IHdpZHRoPScxMDAlJyBoZWlnaHQ9JzEwMCUnIGZpbGw9JyNlMGUwZTAnLz4KICAgICAgICAgICAgICAgICAgICA8dGV4dCB4PSc1MCUnIHk9JzUwJScgZm9udC1mYW1pbHk9J01vbnRzZXJyYXQsIHNhbnMtc2VyaWYnIGZvbnQtc2l6ZT0nNjAnIGZpbGw9JyMzMzMnIHRleHQtYW5jaG9yPSdtaWRkbGUnIGRvbWluYW50LWJhc2VsaW5lPSdtaWRkbGUnIGZvbnQtd2VpZ2h0PSdib2xkJz4KICAgICAgICAgICAgICAgICAgICAgICAg0JzQtdGI0L7Rh9C10LoKICAgICAgICAgICAgICAgICAgICA8L3RleHQ+CiAgICAgICAgICAgICAgICA8L3N2Zz4=", "Мешочек для молока", 350m }
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
