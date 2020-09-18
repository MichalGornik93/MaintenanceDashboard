using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Data.Models
{
    public class Thermostat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BarcodeNumber { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        [Required]
        public string AddedDate { get; set; }
        public string Comments { get; set; }
        public string LastPrevention { get; set; }
        public string CurrentLocation { get; set; }
        public string LastWashDate { get; set; }
        public virtual ICollection<ReceivedThermostat> ReceivedThermostats { get; set; }
        public virtual ICollection<SpendedThermostat> SpendedThermostats { get; set; }
    }
}
