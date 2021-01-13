using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceDashboard.Data.Models
{
    public class ReceivedThermostat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ReceivingEmployee { get; set; }
        [ForeignKey("Thermostat")]
        public int ThermostatId { get; set; }
        [Required]
        public DateTime ReceivedDate { get; set; }
        [Required]
        public string ActivityPerformed { get; set; }
        public string DescriptionIntervention { get; set; }
        public string LastLocation { get; set; }
        public virtual Thermostat Thermostat { get; set; }
    }
}
