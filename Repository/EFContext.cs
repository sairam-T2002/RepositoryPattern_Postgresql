using Microsoft.EntityFrameworkCore;
using Repository.Models;
namespace Repository
{
    public partial class EFContext : DbContext
    {
        public EFContext( DbContextOptions<EFContext> options ) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
