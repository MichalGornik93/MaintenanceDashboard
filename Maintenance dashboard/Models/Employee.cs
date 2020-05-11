using System.ComponentModel.DataAnnotations;

namespace Maintenance_dashboard
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
