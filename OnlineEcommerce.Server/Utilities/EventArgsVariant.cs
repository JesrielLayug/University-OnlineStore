using OnlineEcommerce.Server.Component_Models;

namespace OnlineEcommerce.Server.Utilities
{
    public class EventArgsVariant : EventArgs
    {
        public ComponentProductVariant _variant { get; }
        public EventArgsVariant(ComponentProductVariant variant)
        {
            _variant = variant;
        }
    }
}
