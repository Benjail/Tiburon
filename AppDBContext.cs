using Microsoft.EntityFrameworkCore;

namespace Tiburon.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)//(OptionsBuilder<AppDBContext> builder)
        //{

        //    builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TiburonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");   
        //}
       public DbSet<Survey> Surveys { get; set; } 
       public DbSet<Result> Results { get; set; } 
       public DbSet<Interview> Interviews { get; set; }  
       public DbSet<Question> Questions { get; set; }
       public DbSet<Answer> Answers { get; set; }
    }
}
