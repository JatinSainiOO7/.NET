using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace VidlyApp.Data
{
    public class VidlyAppContext : DbContext
    {
        public VidlyAppContext(DbContextOptions<VidlyAppContext> options) : base(options) { }




        public DbSet<Expense> Expenses { get; set; } = null!;

    }
}
 