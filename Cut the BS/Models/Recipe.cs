using System.ComponentModel.DataAnnotations;

namespace Cut_the_BS.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ingredients { get; set; }
        public string? Instructions { get; set; }
        public string? Image { get; set; }
        public string? Catagory { get; set; }

    }
}
