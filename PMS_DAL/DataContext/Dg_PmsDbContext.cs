using Microsoft.EntityFrameworkCore;

namespace PMS_DAL.DataContext
{
    public class Dg_PmsDbContext : DbContext
    {
        public Dg_PmsDbContext(DbContextOptions<Dg_PmsDbContext> options) : base(options)
        {       
            
        }
    }
}
