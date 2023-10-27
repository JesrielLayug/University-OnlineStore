namespace OnlineEcommerce.Server.Utilities
{
    public class StringFunction
    {
        public string LimitText(string input, int maxLength)
        {
            if (input.Length <= maxLength)
            {
                return input;
            }
            else
            {
                return input.Substring(0, maxLength) + "...";
            }
        }
    }
}
