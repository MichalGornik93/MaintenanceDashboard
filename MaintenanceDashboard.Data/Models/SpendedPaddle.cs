using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceDashboard.Data.Models
{
    public class SpendedPaddle
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Paddle")]
        public int PaddleId { get; set; }
        [Required]
        public DateTime ReceivedDate { get; set; }
        [Required]
        public string ActivityPerformed { get; set; }
        [Required]
        public DateTime RepairDate { get; set; }
        [Required]
        public string DescriptionIntervention { get; set; }
        [Required]
        public string ReceivingEmployee { get; set; }
        [Required]
        public string SpendingEmployee { get; set; }
        public virtual Paddle Paddle { get; set; }
    }
}
