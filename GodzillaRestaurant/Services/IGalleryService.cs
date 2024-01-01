using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface IGalleryService
    {
        public IEnumerable<GalleryItem> GetAllGallery();
        public GalleryItem GetGalleryItem(int id);
        public void AddGalleryItem(GalleryItem _galleryItem);
        public void DeleteGalleryItem(int id);
    }
}
