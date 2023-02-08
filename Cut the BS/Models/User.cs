using System.ComponentModel.DataAnnotations;

namespace Cut_the_BS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }
    }
}
