using DeratMain.Databases.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface IImageRepository
    {
        Task<IEnumerable<IndexImage>> GetAllImagesAsync();

        Task AddImageAsync(IndexImage image);
    }
}
