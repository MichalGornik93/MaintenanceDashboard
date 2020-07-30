using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Domain
{
    public class RegisterTool
    {
        [Key]
        public int Id { get; set; }
        public string ToolName { get; set; }
        public string UidCode { get; set; }
    }
}
