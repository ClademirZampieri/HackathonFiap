﻿using Hackathon.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Core.DTO
{
    public class NewUserDto : Entity
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
