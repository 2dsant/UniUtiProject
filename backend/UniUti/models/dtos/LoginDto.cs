using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniUti.models.dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório.")]
        public string? Senha { get; set; }
    }
}