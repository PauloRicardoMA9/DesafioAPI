﻿using System;

namespace ma9.Business.Models
{
    public class Contato : Entity
    {
        public Guid ClienteId { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Cliente Cliente { get; set; }
    }
}
