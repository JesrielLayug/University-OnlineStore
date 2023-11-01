using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Utilities
{
    public class EventArgsEditProduct : EventArgs
    {
        public DTO_Product _product { get; }

        public EventArgsEditProduct(DTO_Product product)
        {
            _product = product;
        }
    }

    public static class StaticProduct
    {
        private static DTO_Product Product = new DTO_Product();
        public static event EventHandler<EventArgsEditProduct> ClickEdit;
        public static event EventHandler<EventArgsEditProduct> ClickRemove;

        public static void InsertProductToEdit(DTO_Product product)
        {
            Product = product;
            Add(product);
        }

        public static void Add(DTO_Product product)
        {
            ClickEdit?.Invoke(null, new EventArgsEditProduct(product));
        }

        public static async Task RemoveProductToEdit(DTO_Product product)
        {
            Product = new DTO_Product();
            await Remove(product);
        }

        public static async Task Remove(DTO_Product product)
        {
            ClickRemove?.Invoke(null, new EventArgsEditProduct(product));
        }

        public static DTO_Product GetProduct()
        {
            return Product;
        }
    }
}
