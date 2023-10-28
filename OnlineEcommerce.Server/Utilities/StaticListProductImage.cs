using MudBlazor;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Utilities
{
    public class EventArgsImage : EventArgs
    {
        public DTO_ProductImage _image { get; }

        public EventArgsImage(DTO_ProductImage image)
        {
            _image = image;
        }
    }

    public static class StaticListProductImage
    {
        private static List<DTO_ProductImage> Images = new List<DTO_ProductImage>();
        public static event EventHandler<EventArgsImage> ClickAddImage;
        public static event EventHandler<EventArgsImage> ClickRemoveImage;

        public static void AddImage(DTO_ProductImage image)
        {
            Images.Add(image);
            ImageAdded(image);
        }

        public static void RemoveImage(DTO_ProductImage image)
        {
            Images.Remove(image);
            ImageRemove(image);
        }

        public static void RemoveAll(List<DTO_ProductImage> images)
        {
            images.Clear();
        }

        public static List<DTO_ProductImage> GetImages()
        {
            return Images;
        }

        public static void ImageAdded(DTO_ProductImage image)
        {
            ClickAddImage?.Invoke(null, new EventArgsImage(image));
        }

        public static void ImageRemove(DTO_ProductImage image)
        {
            ClickRemoveImage?.Invoke(null, new EventArgsImage(image));
        }
    }
}
