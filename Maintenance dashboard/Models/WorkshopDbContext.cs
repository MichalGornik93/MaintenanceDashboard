using System.Data.Entity;

namespace Maintenance_dashboard
{
    public class WorkshopDbContext:DbContext
    {
        public DbSet <Employee> Employees { get; set; }
        public DbSet<RegisterTool> RegisterTools  { get; set; }

        public WorkshopDbContext()
            :base("name=WorkshopDbContext")
        {}
    }
}
