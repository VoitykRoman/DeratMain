using DeratMain.Databases.Entities;
using DeratMain.Models.IndexImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IIndexImageService
    {
        Task<IEnumerable<IndexImage>> GetAllIndexImages();

        Task AddIndexImage(IndexImageCreateModel indexImage);

        Task UpdateImageAsync(IndexImageUpdateModel image);

        Task<IndexImage> GetIndexImageAsync(int id);

        Task DeleteIndexImageAsync(int id);
    }
}
