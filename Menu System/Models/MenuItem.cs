using System.ComponentModel.DataAnnotations;

namespace Menu_System.Models
{
    public class MenuItem
    {
        [Key] 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
