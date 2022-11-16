using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseContext : IdentityDbContext<CustomeUser>
    {
        public DbSet<Customer> Customers {  get;  set; }
        public DbSet<Provider> Provider { get; set; }

        public DbSet<Post> posts { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<CustomeUser> customeUsers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
