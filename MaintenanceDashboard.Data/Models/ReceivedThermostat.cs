using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Data.Domain
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
        public string ReceivedDate { get; set; }
        [Required]
        public string ActivityPerformed { get; set; }
        [Required]
        public string PlannedRepairDate { get; set; }
        public string Comments { get; set; }
        [Required]
        public string IsOrders { get; set; }
        public string LastLocation { get; set; }
        public virtual Thermostat Thermostat { get; set; }
    }
}
