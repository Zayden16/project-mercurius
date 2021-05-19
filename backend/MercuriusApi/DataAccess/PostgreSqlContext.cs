using MercuriusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MercuriusApi.DataAccess
{
    public class PostgreSqlContext: DbContext  
    {  
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)  
        {  
        }  
  
        public DbSet<User> Users { get; set; }  
  
        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            //builder.Entity<User>().HasKey()

            base.OnModelCreating(builder);  
        }  
  
        public override int SaveChanges()  
        {  
            ChangeTracker.DetectChanges();  
            return base.SaveChanges();  
        }  
    }  
}
