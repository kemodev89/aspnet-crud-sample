using Microsoft.EntityFrameworkCore;
using aspnet_crud_sample.Models;

namespace aspnet_crud_sample {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
