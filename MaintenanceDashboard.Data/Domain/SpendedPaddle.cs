using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceDashboard.Data.Domain
{
    public class SpendedPaddle
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Paddle")]
        public int PaddleId { get; set; }
        
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

        public virtual Employee ReceivingEmployee { get; set; }

        public virtual Employee SpendingEmployee { get; set; }

        public virtual Paddle Paddle { get; set; }
    }
}
