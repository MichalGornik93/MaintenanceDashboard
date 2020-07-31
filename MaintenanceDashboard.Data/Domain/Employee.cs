using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceDashboard.Data.Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set; }
        public string UidCode { get; set; }
        
        public virtual ICollection<ReceivedPaddle> ReceivedPaddles { get; set; }

        [InverseProperty("ReceivingEmployee")]
        public virtual ICollection<SpendedPaddle> ReceivingPaddles { get; set; }

        [InverseProperty("SpendingEmployee")]
        public virtual ICollection<SpendedPaddle> SpendingEmployee { get; set; }
    }
}
