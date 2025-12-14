using Microsoft.EntityFrameworkCore;
using EcoShop.Models;

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

            // 2. Товары (Картинки теперь на русском)
            modelBuilder.Entity<Product>().HasData(
                new Product { 
                    Id = 1, 
                    Name = "Бамбуковая зубная щетка", 
                    CategoryId = 2, 
                    Price = 250, 
                    Description = "100% биоразлагаемая ручка. Угольное напыление.", 
                    // Текст после ?text= изменен на русский (пробелы заменены на +)
                    ImageUrl = "https://placehold.co/600x400/81c784/ffffff?text=Бамбуковая+щетка" 
                },
                new Product { 
                    Id = 2, 
                    Name = "Твердый шампунь", 
                    CategoryId = 2, 
                    Price = 380, 
                    Description = "Экономичный и натуральный. Хватает на 3 месяца.", 
                    ImageUrl = "https://placehold.co/600x400/ba68c8/ffffff?text=Твердый+шампунь" 
                },
                new Product { 
                    Id = 3, 
                    Name = "Натуральный дезодорант", 
                    CategoryId = 2, 
                    Price = 550, 
                    Description = "Кристалл алунит. Без запаха и пятен.", 
                    ImageUrl = "https://placehold.co/600x400/f8bbd0/ffffff?text=Дезодорант" 
                },
                new Product { 
                    Id = 4, 
                    Name = "Спонж Конняку", 
                    CategoryId = 2, 
                    Price = 300, 
                    Description = "Для мягкого очищения лица. 100% растительный.", 
                    ImageUrl = "https://placehold.co/600x400/26a69a/ffffff?text=Спонж" 
                },
                new Product { 
                    Id = 5, 
                    Name = "Эко-сумка (Шоппер)", 
                    CategoryId = 1, 
                    Price = 500, 
                    Description = "Прочный органический хлопок. Выдерживает 15 кг.", 
                    ImageUrl = "https://placehold.co/600x400/d7ccc8/5d4037?text=Эко-сумка" 
                },
                new Product { 
                    Id = 6, 
                    Name = "Термокружка KeepCup", 
                    CategoryId = 1, 
                    Price = 1200, 
                    Description = "Стильная, держит тепло 2 часа. Стекло и пробка.", 
                    ImageUrl = "https://placehold.co/600x400/4fc3f7/ffffff?text=Термокружка" 
                },
                new Product { 
                    Id = 7, 
                    Name = "Металлические трубочки", 
                    CategoryId = 1, 
                    Price = 600, 
                    Description = "Набор 4 шт + ершик. Нержавеющая сталь.", 
                    ImageUrl = "https://placehold.co/600x400/cfd8dc/455a64?text=Трубочки" 
                },
                new Product { 
                    Id = 8, 
                    Name = "Восковые салфетки", 
                    CategoryId = 1, 
                    Price = 800, 
                    Description = "Замена пищевой пленке. Хлопок + пчелиный воск.", 
                    ImageUrl = "https://placehold.co/600x400/ffecb3/ff6f00?text=Салфетки" 
                },
                new Product { 
                    Id = 9, 
                    Name = "Гранола домашняя", 
                    CategoryId = 3, 
                    Price = 450, 
                    Description = "Запеченные мюсли с орехами и медом. Без сахара.", 
                    ImageUrl = "https://placehold.co/600x400/ffcc80/e65100?text=Гранола" 
                },
                new Product { 
                    Id = 10, 
                    Name = "Чай Матча (Matcha)", 
                    CategoryId = 3, 
                    Price = 990, 
                    Description = "Японский зеленый чай высшего сорта. Бодрит.", 
                    ImageUrl = "https://placehold.co/600x400/66bb6a/ffffff?text=Матча" 
                },
                new Product { 
                    Id = 11, 
                    Name = "Кокосовое масло", 
                    CategoryId = 3, 
                    Price = 700, 
                    Description = "Extra Virgin. Для жарки и косметических целей.", 
                    ImageUrl = "https://placehold.co/600x400/ffffff/333333?text=Масло" 
                },
                new Product { 
                    Id = 12, 
                    Name = "Мешочек для орехового молока", 
                    CategoryId = 3, 
                    Price = 350, 
                    Description = "Нейлоновый мешочек для фильтрации молока.", 
                    ImageUrl = "https://placehold.co/600x400/e0e0e0/333333?text=Мешочек" 
                }
            );
        }
    }
}