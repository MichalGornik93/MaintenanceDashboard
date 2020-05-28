using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Domain
{
    public class RegisterTool
    {
        public int Id { get; set; }
        public string ToolName { get; set; }
        public string UidCode { get; set; }
    }
}
