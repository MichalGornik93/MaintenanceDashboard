using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceDashboard.Data.Domain
{
    public class ReceivedPaddle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ReceivingEmployee { get; set; }
        [Required]
        public string PaddleNumber { get; set; }
        [Required]
        public string AddedDate { get; set; }
        [Required]
        public string ActivityPerformed { get; set; }
        [Required]
        public string PlannedRepairDate { get; set; }
        public string Comments { get; set; }
        [Required]
        public string IsOrders { get; set; }
    }
}
