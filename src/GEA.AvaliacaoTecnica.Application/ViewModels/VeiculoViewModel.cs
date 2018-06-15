using System;
using System.ComponentModel.DataAnnotations;

namespace GEA.AvaliacaoTecnica.Application.ViewModels
{
    public class VeiculoViewModel
    {
        public VeiculoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo 'Placa' é obrigatório.")]
        [MaxLength(7, ErrorMessage = "Máximo 7 caracteres.")]
        [MinLength(7, ErrorMessage = "Mínimo 7 caracteres.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo 'Modelo' é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo 'Marca' é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres.")]
        public string Marca { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}
