﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Data.Models
{
    public class Paddle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BarcodeNumber { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        public DateTime LastPreventionDate { get; set; }
        public string Comments { get; set; }
        public virtual ICollection<ReceivedPaddle> ReceivedPaddles { get; set; }
        public virtual ICollection<SpendedPaddle> SpendedPaddles { get; set; }
    }
}
