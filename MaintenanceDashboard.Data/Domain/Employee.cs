using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set; }
        public string UidCode { get; set; }
        public virtual ICollection<ReceivedPaddle> ReceivedPaddles { get; set; }
    }
}
