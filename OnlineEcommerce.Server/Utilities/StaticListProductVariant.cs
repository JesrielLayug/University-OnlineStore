
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Utilities
{
    public class EventArgsVariant : EventArgs
    {
        public DTO_ProductVariant _variant { get; }
        public EventArgsVariant(DTO_ProductVariant variant)
        {
            _variant = variant;
        }
    }

    public static class StaticListProductVariant
    {
        private static List<DTO_ProductVariant> Variants = new List<DTO_ProductVariant>();
        public static event EventHandler<EventArgsVariant> ClickAddVariant;
        public static event EventHandler<EventArgsVariant> ClickRemoveVariant;

        public static void AddVariant(DTO_ProductVariant variant)
        {
            Variants.Add(variant);
            VariantAdded(variant);
        }

        public static void RemoveVariant(DTO_ProductVariant variant)
        {
            Variants.Remove(variant);
            VariantRemove(variant);
        }

        public static List<DTO_ProductVariant> GetVariants()
        {
            return Variants;
        }

        public static void VariantAdded(DTO_ProductVariant variant)
        {
            ClickAddVariant?.Invoke(null, new EventArgsVariant(variant));
        }

        public static void VariantRemove(DTO_ProductVariant variant)
        {
            ClickRemoveVariant?.Invoke(null, new EventArgsVariant(variant));
        }

    }
}
