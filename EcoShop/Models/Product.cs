using System.ComponentModel.DataAnnotations;

namespace EcoShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название товара")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // Ошибка диапазона цен
        [Range(1, 1000000, ErrorMessage = "Цена должна быть от 1 ₽")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public string ImageUrl { get; set; } = "";

        public List<ProductReview> Reviews { get; set; } = new();
        public double AverageRating => Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;
    }
}