using System;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Domain
{
    public class ReceivedPaddle
    {
        public int Id { get; set; }
        [Required]
        public string Employee { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string DateAdded { get; set; }
        [Required]
        public string PreventiveAction { get; set; }
        [Required]
        public string PlannedRepairTime { get; set; }
        public string Comments { get; set; }
        [Required]
        public string IsOrders { get; set; }
    }
}
