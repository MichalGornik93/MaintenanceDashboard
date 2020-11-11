using MaintenanceDashboard.Data.Models;
using System.Data.Entity;

namespace MaintenanceDashboard.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Paddle> Paddles { get; set; }
        public DbSet<ReceivedPaddle> ReceivedPaddles { get; set; }
        public DbSet<SpendedPaddle> SpendedPaddles { get; set; }
        public DbSet<Thermostat> Thermostats { get; set; }
        public DbSet<ReceivedThermostat> ReceivedThermostats { get; set; }
        public DbSet<SpendedThermostat> SpendedThermostats { get; set; }

        public DataContext()
            :base("name=DataContext")
        {}
    }
}
