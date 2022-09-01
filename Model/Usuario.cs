﻿using System;
using System.Collections.Generic;

namespace WebAPIExample.Model
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public long Cpf { get; set; }
        public int Cep { get; set; }
    }
}
