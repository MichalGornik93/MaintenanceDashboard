using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Data.Domain
{
    public class Thermostat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BarcodeNumber { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string AddedDate { get; set; }
        public string Comments { get; set; }
        public string LastPrevention { get; set; }
        public bool IsInWorkshop { get; set; }
    }
}
