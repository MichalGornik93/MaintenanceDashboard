using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Data.Domain
{
    public class SpendedThermostat
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Thermostat")]
        public int ThermostatId { get; set; }
        [Required]
        public string AddedDate { get; set; }
        [Required]
        public string ActivityPerformed { get; set; }
        [Required]
        public string RepairDate { get; set; }
        public string Comments { get; set; }
        [Required]
        public string IsOrders { get; set; }
        [Required]
        public string DescriptionIntervention { get; set; }
        [Required]
        public string ReceivingEmployee { get; set; }
        [Required]
        public string SpendingEmployee { get; set; }
        public virtual Thermostat Thermostat { get; set; }
    }
}
