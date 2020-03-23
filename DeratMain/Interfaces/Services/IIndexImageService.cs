using DeratMain.Databases.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IIndexImageService
    {
        Task<IEnumerable<IndexImage>> GetAllIndexImages();

        Task AddIndexImage(string url);
    }
}
