﻿namespace Hackathon.Core.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string CPF { get; set; } 
        public string CRM { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}