﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC7.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short Price { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        [Required]
        [StringLength(50)]
        public string SubscriptionType { get; set; }

        public static readonly byte Free = 1;
    }
}