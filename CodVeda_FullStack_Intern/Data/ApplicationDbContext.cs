//AppDB C
using Microsoft.EntityFrameworkCore;
using CodVeda_FullStack_Intern.Models;

namespace CodVeda_FullStack_Intern.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Seed the hardcoded Admin
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FullName = "System Admin",
                Email = "admin@gmail.com",
                Password = "&0137Admin"
            });

            // 2. Seed the 3 Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "BookFlow History",
                    Publisher = "CodVeda Press",
                    PublishDate = "2024",
                    Summary = "The comprehensive history of how the BookFlow library management system was developed during the internship."
                },
                new Book
                {
                    Id = 2,
                    Title = "UfsConnectBook History",
                    Publisher = "University Press",
                    PublishDate = "2023",
                    Summary = "Exploring the digital transformation of student connections and resource sharing in academic environments."
                },
                new Book
                {
                    Id = 3,
                    Title = "Lindele's History",
                    Publisher = "Tech Pioneers Publishing",
                    PublishDate = "2025",
                    Summary = "A deep dive into the journey of Lindele Nyambe, focusing on software engineering milestones and future visions."
                }
            );
        }
    }
}
