using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GEA.AvaliacaoTecnica.Application.ViewModels
{
    public class UserRegisterViewModel
    {

        [Required(ErrorMessage = "O campo 'Empresa' é obrigatório.")]
        [Display(Name = "Empresa")]
        public Guid EmpresaId { get; set; }

        public IEnumerable<EmpresaViewModel> Empresas { get; set; }
        public UsuarioViewModel Usuario {get;set;}

        [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' é obrigatório.")]
        [StringLength(100, ErrorMessage = "O/A {0} deve ter no mínimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo 'Confirmar Senha' é obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não correspondem.")]
        public string ConfirmPassword { get; set; }
    }
}
