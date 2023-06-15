using Microsoft.EntityFrameworkCore;
using Puzzle.Models;

namespace Puzzle.DAL
{
    public class PuzzleDbContext : DbContext
    {
        public PuzzleDbContext()
        {
            Database.EnsureCreated();
        }

        public PuzzleDbContext(DbContextOptions<PuzzleDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Result> Result { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PuzzleDbcontext;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasMany(x => x.Result).WithOne(x => x.User);

            });
            modelBuilder.Entity<Result>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasOne(x => x.User).WithMany(x => x.Result);

                SeedData(modelBuilder);
            });
            
             void SeedData(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>().HasData(new User
                {
                    Id = 1,
                    Login = "guralvital0@gmail.com",
                    Password = "qwerty12345"
                });
               
                modelBuilder.Entity<Result>().HasData(new Result
                {
                    Id = 1,
                    MovesCount = 3,
                    TimeTaken = TimeSpan.FromMinutes(90),
                    UserId = 1
                });
            }
        }
    }
}


