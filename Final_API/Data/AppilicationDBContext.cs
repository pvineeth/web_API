using Final_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_API.Data
{
    public class AppilicationDBContext :DbContext
    {
        public AppilicationDBContext(DbContextOptions<AppilicationDBContext>options)
            :base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
