using System.ComponentModel.DataAnnotations;

namespace DeratMain.Models.IndexImage
{
    public class IndexImageCreateModel
    {
        public string ImageUrl { get; set; }
        [MaxLength(10)]
        public string Title { get; set; }
        [MaxLength(25)]
        public string Description { get; set; }
    }
}
