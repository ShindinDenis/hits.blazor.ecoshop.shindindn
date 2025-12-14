using EcoShop.Models;

namespace EcoShop.Services
{
    public class CartService
    {
        private readonly BrowserStorageService _storage;
        public List<OrderItem> Items { get; private set; } = new();
        public event Action? OnChange;

        public CartService(BrowserStorageService storage)
        {
            _storage = storage;
        }

        // Загрузка корзины при старте
        public async Task InitializeAsync()
        {
            var storedItems = await _storage.GetDataAsync<List<OrderItem>>("cart_items");
            if (storedItems != null)
            {
                Items = storedItems;
                NotifyStateChanged();
            }
        }

        public async Task AddToCart(Product product)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                Items.Add(new OrderItem { Product = product, Quantity = 1 });
            }
            await SaveCart();
            NotifyStateChanged();
        }

        public async Task DecreaseQuantity(Product product)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity--;
                if (existingItem.Quantity <= 0) Items.Remove(existingItem);
                await SaveCart();
                NotifyStateChanged();
            }
        }

        public async Task RemoveItem(Product product)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                Items.Remove(existingItem);
                await SaveCart();
                NotifyStateChanged();
            }
        }

        public async Task ClearCart()
        {
            Items.Clear();
            await SaveCart();
            NotifyStateChanged();
        }

        private async Task SaveCart()
        {
            await _storage.SaveDataAsync("cart_items", Items);
        }

        public decimal TotalPrice => Items.Sum(i => i.Product.Price * i.Quantity);
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}