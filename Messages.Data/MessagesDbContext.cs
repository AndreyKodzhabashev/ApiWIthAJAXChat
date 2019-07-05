using Messages.Domain;
using Microsoft.EntityFrameworkCore;

namespace Messages.Data
{
    public class MessagesDbContext : DbContext
    {

        public MessagesDbContext()
        {
        }

        public MessagesDbContext(DbContextOptions<MessagesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}
