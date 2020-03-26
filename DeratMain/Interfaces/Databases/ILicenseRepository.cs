using DeratMain.Databases.Entities;
using DeratMain.Models.License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Databases
{
    public interface ILicenseRepository
    {
        Task<IEnumerable<License>> GetAllLicensesAsync();

        Task<License> GetLicenseAsync(int id);

        Task AddLicenseAsync(License license);

        Task UpdateLicenseAsync(License license);

        Task DeleteLicenseAsync(int id);
    }
}
