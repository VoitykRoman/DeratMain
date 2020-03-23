using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
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

        public async Task AddIndexImage(string url)
        {
            var image = new IndexImage()
            {
                ImageUrl = url
        };
            await _imageRepository.AddImageAsync(image);
        }

        public async Task<IEnumerable<IndexImage>> GetAllIndexImages()
        {
            return await _imageRepository.GetAllImagesAsync();
        }
    }
}
