using first_api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace first_api.Data
{
    public class AppDpContext : DbContext
    {
        public AppDpContext(DbContextOptions<AppDpContext>options ) : base(options)
        { 
        
        
        }
        public DbSet<Category> Categories { get; set; }
    }
}
