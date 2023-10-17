namespace OnlineEcommerce.Server.Utilities
{
    public static class SKUGenerator
    {
        public static string GenerateSKU(string productName, string organizationName, int productID)
        {
            string baseSKU = $"{productName.ToUpper().Substring(0, 3)}{organizationName.ToUpper().Substring(0, 2)}";

            string uniqueID = productID.ToString("D5"); 

            string generatedSKU = $"{baseSKU}-{uniqueID}";

            return generatedSKU;
        }
    }
}
