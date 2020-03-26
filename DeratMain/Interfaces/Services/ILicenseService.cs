using DeratMain.Databases.Entities;
using DeratMain.Models.License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface ILicenseService
    {
        Task<IEnumerable<License>> GetAllLicensesAsync();

        Task<License> GetLicenseAsync(int id);

        Task AddLicenseAsync(LicenseCreateModel licenseCreateModel);

        Task UpdateLicenseAsync(LicenseUpdateModel licenseUpdateModel);

        Task DeleteLicenseAsync(int id);
    }
}
