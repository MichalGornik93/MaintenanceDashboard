using System;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Domain
{
    public class GetedPaddle
    {
        public int Id { get; set; }
        [Required]
        public string Employee { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        public string PreventiveAction { get; set; }
        [Required]
        public string PlannedRepairTime { get; set; }
        public string CommentsGetedPaddle { get; set; }
        [Required]
        public string IsOrders { get; set; }
    }
}
