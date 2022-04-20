using Microsoft.EntityFrameworkCore;

namespace Api1.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Note> Note { get; set; }
        public DbSet<User> User { get; set; }


    }
}
