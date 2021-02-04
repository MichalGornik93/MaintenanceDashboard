using System;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Models
{
    public class SpendedRobotTool
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string SpendingEmployee { get; set; }
        public DateTime Date { get; set; }
        public bool IsDoubler { get; set; }
    }
}
