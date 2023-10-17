using OnlineEcommerce.Server.Component_Models;

namespace OnlineEcommerce.Server.Utilities
{
    public static class StaticListProductVariant
    {
        private static List<ComponentProductVariant> Variants = new List<ComponentProductVariant>();
        public static event EventHandler<EventArgsVariant> ClickAddVariant;
        public static event EventHandler<EventArgsVariant> ClickRemoveVariant;

        public static void AddVariant(ComponentProductVariant variant)
        {
            bool variantExist = Variants.Any(v => v.Color == variant.Color && v.Size == variant.Size);
            Variants.Add(variant);
            VariantAdded(variant);
        }

        public static void RemoveVariant(ComponentProductVariant variant)
        {
            Variants.Remove(variant);
            VariantRemove(variant);
        }

        public static List<ComponentProductVariant> GetVariants()
        {
            return Variants;
        }

        public static void VariantAdded(ComponentProductVariant variant)
        {
            ClickAddVariant?.Invoke(null, new EventArgsVariant(variant));
        }

        public static void VariantRemove(ComponentProductVariant variant)
        {
            ClickRemoveVariant?.Invoke(null, new EventArgsVariant(variant));
        }

    }
}
