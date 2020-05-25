﻿using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Domain
{
    public class RegisterTool
    {
        public int Id { get; set; }
        [Required]
        public string ToolName { get; set; }
        [Required]
        public string UidCode { get; set; }
    }
}