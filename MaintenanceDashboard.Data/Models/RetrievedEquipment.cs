using System;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Models
{
    public class RetrievedEquipment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Employee { get; set; }
        public string Action { get; set; }
    }
}
