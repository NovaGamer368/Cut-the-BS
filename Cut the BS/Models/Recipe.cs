using System.ComponentModel.DataAnnotations;


namespace Cut_the_BS.Models
{
    public class Recipe
    {

        [Key]
        public int Id { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public string Ingrediants { get; set; }
        public string Instructions { get; set; }
        public string? Catagory { get; set; }
       
    }
}

