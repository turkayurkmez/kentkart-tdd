using Community.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Community.API.Data
{
    public class SpeakerDbContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }

        public SpeakerDbContext(DbContextOptions<SpeakerDbContext> options):base(options)
        {
                
        }
    }
}
