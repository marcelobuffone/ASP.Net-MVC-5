using System;
using System.ComponentModel.DataAnnotations;


namespace GEA.AvaliacaoTecnica.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres.")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public Guid EmpresaId { get; set; }

        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }

        public EmpresaViewModel Empresa { get; set; }
    }
}
