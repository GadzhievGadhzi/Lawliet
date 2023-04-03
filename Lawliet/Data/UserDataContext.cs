using Lawliet.Controllers;
using Lawliet.Models;
using Microsoft.EntityFrameworkCore;

namespace Lawliet.Data {
    public class UserDataContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<LessonTopic> LessonTopics { get; set; }

        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}