using calendar_server.Models;
using Microsoft.EntityFrameworkCore;

namespace calendar_server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
