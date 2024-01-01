using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class GalleryDAL : IGalleryService
    {
        private AppDBContext _dbContext;

        public GalleryDAL(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GalleryItem> GetAllGallery()
        {
            try
            {
                return _dbContext.GalleryItem.ToList();
            }
            catch
            {
                throw;
            }
        }

        public GalleryItem GetGalleryItem(int id) => _dbContext.GalleryItem.Find(id);

        public void AddGalleryItem(GalleryItem _galleryItem)
        {
            try
            {
                _dbContext.GalleryItem.Add(_galleryItem);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteGalleryItem(int id)
        {
            try
            {
                GalleryItem _galleryItem = _dbContext.GalleryItem.Find(id);
                _dbContext.Remove(_galleryItem);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
