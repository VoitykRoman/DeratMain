using DeratMain.Models.IndexImage;

namespace DeratMain.Databases.Entities
{
    public class IndexImage : BaseEntity
    {
        public IndexImage() : base()
        {
        }

        public IndexImage(IndexImageCreateModel indexImage) : base()
        {
            ImageUrl = indexImage.ImageUrl;
            Title = indexImage.Title;
            Description = indexImage.Description;
        }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
