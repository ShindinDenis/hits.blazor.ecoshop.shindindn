using Microsoft.EntityFrameworkCore;
using EcoShop.Models;
using EcoShop.Utils; // <-- Добавили using
using System;
using System.Text;

namespace EcoShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductReview> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Категории
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Дом и быт" },
                new Category { Id = 2, Name = "Красота и уход" },
                new Category { Id = 3, Name = "Здоровое питание" }
            );

            // 2. Товары с надежными SVG-заглушками
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Бамбуковая зубная щетка", CategoryId = 2, Price = 250, Description = "100% биоразлагаемая ручка.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Бамбуковая щетка", "#81c784") },
                new Product { Id = 2, Name = "Твердый шампунь", CategoryId = 2, Price = 380, Description = "Экономичный и натуральный.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Твердый шампунь", "#ba68c8") },
                new Product { Id = 3, Name = "Натуральный дезодорант", CategoryId = 2, Price = 550, Description = "Кристалл алунит. Без запаха.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Дезодорант", "#f8bbd0", "#333") },
                new Product { Id = 4, Name = "Спонж Конняку", CategoryId = 2, Price = 300, Description = "100% растительный.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Спонж", "#26a69a") },
                new Product { Id = 5, Name = "Эко-сумка (Шоппер)", CategoryId = 1, Price = 500, Description = "Прочный органический хлопок.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Эко-сумка", "#d7ccc8", "#5d4037") },
                new Product { Id = 6, Name = "Термокружка KeepCup", CategoryId = 1, Price = 1200, Description = "Стильная, держит тепло 2 часа.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Термокружка", "#4fc3f7") },
                new Product { Id = 7, Name = "Металлические трубочки", CategoryId = 1, Price = 600, Description = "Набор 4 шт + ершик.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Трубочки", "#cfd8dc", "#455a64") },
                new Product { Id = 8, Name = "Восковые салфетки", CategoryId = 1, Price = 800, Description = "Замена пищевой пленке.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Салфетки", "#ffecb3", "#ff6f00") },
                new Product { Id = 9, Name = "Гранола домашняя", CategoryId = 3, Price = 450, Description = "Запеченные мюсли с орехами.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Гранола", "#ffcc80", "#e65100") },
                new Product { Id = 10, Name = "Чай Матча (Matcha)", CategoryId = 3, Price = 990, Description = "Японский зеленый чай.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Матча", "#66bb6a") },
                new Product { Id = 11, Name = "Кокосовое масло", CategoryId = 3, Price = 700, Description = "Extra Virgin.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Масло", "#ffffff", "#333") },
                new Product { Id = 12, Name = "Мешочек для молока", CategoryId = 3, Price = 350, Description = "Нейлоновый мешочек.", ImageUrl = ImageGenerator.GenerateSvgPlaceholder("Мешочек", "#e0e0e0", "#333") }
            );
        }
    }
}