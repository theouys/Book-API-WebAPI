using System.ComponentModel.DataAnnotations;
namespace bookapi.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public string Author { get; set; }
        
        [Required]
        public string Description { get; set; }


    }
}