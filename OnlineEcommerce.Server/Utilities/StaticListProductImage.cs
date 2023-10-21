using MudBlazor;
using OnlineEcommerce.Server.Component_Models;

namespace OnlineEcommerce.Server.Utilities
{
    public class EventArgsImage : EventArgs
    {
        public ComponentProductImages _image { get; }

        public EventArgsImage(ComponentProductImages image)
        {
            _image = image;
        }
    }

    public static class StaticListProductImage
    {
        private static List<ComponentProductImages> Images = new List<ComponentProductImages>();
        public static event EventHandler<EventArgsImage> ClickAddImage;
        public static event EventHandler<EventArgsImage> ClickRemoveImage;

        public static void AddImage(ComponentProductImages image)
        {
            Images.Add(image);
            ImageAdded(image);
        }

        public static void RemoveImage(ComponentProductImages image)
        {
            Images.Remove(image);
            ImageRemove(image);
        }

        public static List<ComponentProductImages> GetImages()
        {
            return Images;
        }

        public static void ImageAdded(ComponentProductImages image)
        {
            ClickAddImage?.Invoke(null, new EventArgsImage(image));
        }

        public static void ImageRemove(ComponentProductImages image)
        {
            ClickRemoveImage?.Invoke(null, new EventArgsImage(image));
        }
    }
}
