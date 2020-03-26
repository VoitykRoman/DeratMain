using DeratMain.Databases.Entities;
using DeratMain.Interfaces.Databases;
using DeratMain.Interfaces.Services;
using DeratMain.Models.License;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeratMain.Services
{
    public class LicenseService : ILicenseService
    {
        private readonly ILicenseRepository _licenseRepository;

        public LicenseService(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }
        public async Task AddLicenseAsync(LicenseCreateModel licenseCreateModel)
        {
            var license = new License(licenseCreateModel);
            await _licenseRepository.AddLicenseAsync(license);
        }

        public async Task DeleteLicenseAsync(int id)
        {
            await _licenseRepository.DeleteLicenseAsync(id);
        }

        public async Task<IEnumerable<License>> GetAllLicensesAsync()
        {
            return await _licenseRepository.GetAllLicensesAsync();
        }

        public async Task<License> GetLicenseAsync(int id)
        {
            return await _licenseRepository.GetLicenseAsync(id);
        }

        public async Task UpdateLicenseAsync(LicenseUpdateModel licenseUpdateModel)
        {
            var itemToUpdate = await _licenseRepository
                .GetLicenseAsync(licenseUpdateModel.Id);

            itemToUpdate.Description = string.IsNullOrEmpty(licenseUpdateModel.Description)
                ? itemToUpdate.Description
                : licenseUpdateModel.Description;

            itemToUpdate.ImageUrl = string.IsNullOrEmpty(licenseUpdateModel.ImageUrl)
               ? itemToUpdate.ImageUrl
               : licenseUpdateModel.ImageUrl;

            itemToUpdate.IssuedBy = string.IsNullOrEmpty(licenseUpdateModel.IssuedBy)
               ? itemToUpdate.IssuedBy
               : licenseUpdateModel.IssuedBy;

            itemToUpdate.Name = string.IsNullOrEmpty(licenseUpdateModel.Name)
               ? itemToUpdate.Name
               : licenseUpdateModel.Name;

            itemToUpdate.ReadMoreUrl = string.IsNullOrEmpty(licenseUpdateModel.ReadMoreUrl)
              ? itemToUpdate.ReadMoreUrl
              : licenseUpdateModel.ReadMoreUrl;

            await _licenseRepository.UpdateLicenseAsync(itemToUpdate);
        }
    }
}
