using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceDashboard.Data.Models
{
    public class ReceivedPaddle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ReceivingEmployee { get; set; }
        [ForeignKey("Paddle")]
        public int PaddleId { get; set; }
        [Required]
        public DateTime ReceivedDate { get; set; }
        [Required]
        public string ActivityPerformed { get; set; }

        public string DescriptionIntervention { get; set; }
        public virtual Paddle Paddle { get; set; }
    }
}
