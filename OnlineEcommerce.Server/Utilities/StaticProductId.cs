using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Utilities
{
    public class EventArgsEditProduct : EventArgs
    {
        public int _product { get; }

        public EventArgsEditProduct(int product)
        {
            _product = product;
        }
    }

    public static class StaticProductId
    {
        private static int Product;
        public static event EventHandler<EventArgsEditProduct> ClickEdit;
        public static event EventHandler<EventArgsEditProduct> ClickRemove;

        public static void InsertProductToEdit(int product)
        {
            Product = product;
            Add(product);
        }

        public static void Add(int product)
        {
            ClickEdit?.Invoke(null, new EventArgsEditProduct(product));
        }

        public static async Task RemoveProductToEdit(int product)
        {
            Product = 0;
            await Remove(product);
        }

        public static void EditProduct(int product)
        {
            Product = product;
            ClickEdit?.Invoke(null, new EventArgsEditProduct(product));
        }

        public static async Task Remove(int product)
        {
            ClickRemove?.Invoke(null, new EventArgsEditProduct(product));
        }

        public static int GetProduct()
        {
            return Product;
        }
    }
}
