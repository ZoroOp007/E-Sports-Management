using Esports_Management.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Esports_Management.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Test> Test { get; set; }

        public DbSet<UserModel> User { get; set; }
        public DbSet<OrganizerModel> Organizer { get; set; }
        public DbSet<ResultModel> Result { get; set; }
        public DbSet<EventModel> Event { get; set; }
        public DbSet<RegisterModel> Register { get; set; }
        public DbSet<SportModel> Sports { get; set; }
        public DbSet<NewsModel> News { get; set; }  

    }
}