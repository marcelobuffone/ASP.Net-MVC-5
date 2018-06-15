using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GEA.AvaliacaoTecnica.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public EmpresaViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo 'Razão Social' é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [MinLength(10, ErrorMessage = "Mínimo 10 caracteres.")]
        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail Válido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Dia do Vencimento' é obrigatório.")]
        [Range(1,28,ErrorMessage = "Valor entre 1 e 28.")]
        [DisplayName("Dia do Vencimento")]
        public int DiaVencimento { get; set; }
        public DateTime DataCadastro { get; set; }

        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
    }
}
