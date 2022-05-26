using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniUti.models.dtos
{
    public class InstituicaoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email é obrigatório.")]
        [MaxLength(60, ErrorMessage = "Nome inválido. Nome deve possuir até 60 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Cursos é obrigatório.")]
        public ICollection<Curso>? Cursos { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        public Endereco? Endereco { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [MaxLength(10, ErrorMessage = "Número de telefone inválido. Número de telefone deve possuir até 10 caracteres.")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Celular é obrigatório.")]
        [MaxLength(10, ErrorMessage = "Número de celular inválido. Número de celular deve possuir até 10 caracteres.")]
        public string? Celular { get; set; }
    }
}