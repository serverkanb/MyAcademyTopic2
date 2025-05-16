﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic.DTOLayer.Dtos.SubscriberDtos
{
    public class UpdateSubscriberDto
    {
        public int SubscriberId { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
