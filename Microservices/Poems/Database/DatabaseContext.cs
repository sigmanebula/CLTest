using Microsoft.EntityFrameworkCore;

namespace People.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.; initial catalog=Microservices; persist security info=True; user id=sa; password=GDc6GlPQTNMSLPOwNQil;");
        }
    }
}
