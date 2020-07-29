using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceDashboard.Data.Domain
{
    public class ReceivedPaddle
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required]
        [ForeignKey("Paddle")]
        public int NumberId { get; set; }
        [Required]
        public string DateAdded { get; set; }
        [Required]
        public string ActivityPerformed { get; set; }
        [Required]
        public string PlannedRepairTime { get; set; }
        public string Comments { get; set; }
        [Required]
        public string IsOrders { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Paddle Paddle { get; set; }

    }
}
