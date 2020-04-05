using System.ComponentModel.DataAnnotations;

namespace DeratMain.Models.IndexImage
{
    public class IndexImageUpdateModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        
        public string Title { get; set; }
       
        public string Description { get; set; }
    }
}
