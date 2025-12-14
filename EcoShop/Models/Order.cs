using System.ComponentModel.DataAnnotations;

namespace EcoShop.Models
{
    public class OrderItem
    {
        public int Id { get; set; } // ID для базы
        public int ProductId { get; set; } // Ссылка на товар
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть не короче 2 символов")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Адрес обязателен для доставки")]
        public string CustomerAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите телефон для связи")]
        [Phone(ErrorMessage = "Некорректный формат телефона")]
        public string CustomerPhone { get; set; } = string.Empty;

        // Связь с таблицей OrderItems
        public List<OrderItem> Items { get; set; } = new();
        
        public decimal TotalPrice { get; set; } // База данных не хранит вычисляемые поля, сделаем обычным
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; } = false;
    }
}