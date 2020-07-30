using System.Data.Entity;

namespace MaintenanceDashboard.Data.Domain
{
    public class DataContext:DbContext
    {
        public DbSet <Employee> Employees { get; set; }
        public DbSet<RegisterTool> RegisterTools  { get; set; }
        public DbSet<Paddle> Paddles { get; set; }
        public DbSet<ReceivedPaddle> ReceivedPaddles { get; set; }
        public DbSet<SpendedPaddle> SpendedPaddles { get; set; }

        public DataContext()
            :base("name=DataContext")
        {}
    }
}
