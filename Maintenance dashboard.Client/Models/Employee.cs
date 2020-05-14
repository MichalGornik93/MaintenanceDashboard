using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UidCode { get; set; }
    }
}
