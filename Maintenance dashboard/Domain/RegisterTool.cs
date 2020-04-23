using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance_dashboard
{
    class RegisterTool
    {
        public int Id { get; set; }
        [Required]
        public string ToolName { get; set; }
        [Required]
        public string UidCode { get; set; }
    }
}
