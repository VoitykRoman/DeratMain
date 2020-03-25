using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using DeratMain.Models.IndexImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Services
{
    public class IndexImageService : IIndexImageService
    {
        private readonly IImageRepository _imageRepository;

        public IndexImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task AddIndexImage(IndexImageCreateModel indexImage)
        {
            var image = new IndexImage(indexImage);
            await _imageRepository.AddImageAsync(image);
        }

        public async Task DeleteIndexImageAsync(int id)
        {
            await _imageRepository.DeleteIndexImageAsync(id);
        }

        public async Task<IEnumerable<IndexImage>> GetAllIndexImages()
        {
            return await _imageRepository.GetAllImagesAsync();
        }

        public async Task<IndexImage> GetIndexImageAsync(int id)
        {
            return await _imageRepository.GetIndexImageAsync(id);
        }

        public async Task UpdateImageAsync(IndexImageUpdateModel image)
        {
            var itemToUpdate = await _imageRepository.GetIndexImageAsync(image.Id);
            itemToUpdate.Description = string.IsNullOrEmpty(image.Description)
                ? itemToUpdate.Description
                : image.Description;

            itemToUpdate.ImageUrl = string.IsNullOrEmpty(image.ImageUrl)
                ? itemToUpdate.ImageUrl
                : image.ImageUrl;

            itemToUpdate.Title = string.IsNullOrEmpty(image.Title)
                ? itemToUpdate.Title
                : image.Title;

            await _imageRepository.UpdateImageAsync(itemToUpdate);
        }
    }
}
