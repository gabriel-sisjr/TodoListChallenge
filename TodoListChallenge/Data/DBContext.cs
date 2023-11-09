using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListChallenge.Domain.Models;

namespace TodoListChallenge.Data
{
    public class DBContext : IdentityDbContext<UserApp>
    {
        public DBContext(DbContextOptions<DBContext> contextOptions) : base(contextOptions) { }

        public DbSet<ToDoEntity> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);
    }
}
