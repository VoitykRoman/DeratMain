using DeratMain.Models.License;

namespace DeratMain.Databases.Entities
{
    public class License : BaseEntity
    {
        public License(LicenseCreateModel licenseCreateModel): base()
        {
            Name = licenseCreateModel.Name;
            IssuedBy = licenseCreateModel.IssuedBy;
            ImageUrl = licenseCreateModel.ImageUrl;
            Description = licenseCreateModel.Description;
            ReadMoreUrl = licenseCreateModel.ReadMoreUrl;
        }

        public License() : base()
        {
        }

        public string Name { get; set; }
        public string IssuedBy { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string ReadMoreUrl { get; set; }

    }
}
