using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Domain
{
    public class Paddle
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public string Operation { get; set; }
    }
}
