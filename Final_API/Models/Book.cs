using System.ComponentModel.DataAnnotations;

namespace Final_API.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public string? Description { get; set; }
    }
}
