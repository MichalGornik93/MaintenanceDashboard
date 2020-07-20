﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Domain
{
    public class Paddle
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string AddedDate { get; set; }
        public string Comments { get; set; }
    }
}
