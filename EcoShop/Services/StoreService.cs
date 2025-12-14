using EcoShop.Data;
using EcoShop.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoShop.Services
{
    public class StoreService
    {
        private readonly AppDbContext _context;

        public StoreService(AppDbContext context)
        {
            _context = context;
        }

        // --- Получение данных ---
        public List<Product> GetProducts() 
        {
            // Include(r => r.Reviews) подгружает отзывы из связанной таблицы
            return _context.Products.Include(p => p.Reviews).ToList();
        }

        public List<Category> GetCategories() => _context.Categories.ToList();
        
        public List<Order> GetOrders() 
        {
            return _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
        }

        public Product? GetProductById(int id) 
        {
            return _context.Products
                .Include(p => p.Reviews)
                .FirstOrDefault(p => p.Id == id);
        }

        // --- Управление товарами ---
        public void AddProduct(Product product)
        {
            if(string.IsNullOrEmpty(product.ImageUrl)) 
                product.ImageUrl = "https://placehold.co/600x400?text=No+Image";
            
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null) 
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        // --- Категории ---
        public void AddCategory(string name)
        {
            _context.Categories.Add(new Category { Name = name });
            _context.SaveChanges();
        }

        // --- Заказы ---
        public void PlaceOrder(Order order)
        {
            // Пересчитываем TotalPrice перед сохранением
            order.TotalPrice = order.Items.Sum(i => i.Product.Price * i.Quantity);
            order.OrderDate = DateTime.Now;
            order.IsCompleted = false;

            // Важный момент: EF Core может попытаться создать дубликаты продуктов,
            // если мы передаем ему объекты Product внутри OrderItem.
            // Нам нужно сказать EF, что эти продукты уже существуют, мы просто ссылаемся на них.
            foreach(var item in order.Items)
            {
                item.ProductId = item.Product.Id;
                item.Product = null!; // Обнуляем навигационное свойство, чтобы EF не дублировал товар
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void CompleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                order.IsCompleted = true;
                _context.SaveChanges();
            }
        }
        
        // --- Отзывы ---
        public void AddReview(int productId, ProductReview review)
        {
            review.ProductId = productId;
            review.Date = DateTime.Now;
            
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
        public void UpdateProduct(Product product)
{
    // Находим существующий товар в базе
    var existingProduct = _context.Products.Find(product.Id);
    
    if (existingProduct != null)
        {
        // Обновляем поля
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.CategoryId = product.CategoryId;
        existingProduct.Description = product.Description;
        existingProduct.ImageUrl = product.ImageUrl;

        // Сохраняем
        _context.SaveChanges();
            }
        }
    }
    
}