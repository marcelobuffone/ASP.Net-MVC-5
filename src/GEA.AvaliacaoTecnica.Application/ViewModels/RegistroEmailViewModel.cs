using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Application.ViewModels
{
    public class RegistroEmailViewModel
    {
        public RegistroEmailViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo 'Conteúdo' é obrigatório.")]
        [MinLength(10, ErrorMessage = "Mínimo 10 caracteres.")]
        [DisplayName("Conteúdo")]
        public string texto { get; set; }

        [Required(ErrorMessage = "O campo 'Título' é obrigatório.")]
        [MinLength(10, ErrorMessage = "Mínimo 10 caracteres.")]
        [DisplayName("Título")]
        public string titulo { get; set; }
        public Guid CompetenciaAbertaId { get; set; }
        public virtual CompetenciaAberturaViewModel CompetenciaAberta { get; set; }
    }
}
