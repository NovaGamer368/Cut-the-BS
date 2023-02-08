using Microsoft.EntityFrameworkCore;
using Cut_the_BS.Models;

namespace Cut_the_BS.Data
{
    

    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<User> Users { get; set; }
        }
    

}
