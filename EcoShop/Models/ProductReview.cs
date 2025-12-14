namespace EcoShop.Models
{
    public class ProductReview
    {
        public int Id { get; set; } // Добавили ID для базы
        public int ProductId { get; set; } // Ссылка на товар
        public string UserName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}