using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GEA.AvaliacaoTecnica.Application.ViewModels
{
    public class RegistroEntradaViewModel
    {
        public RegistroEntradaViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [ScaffoldColumn(false)]
        public DateTime HoraEntrada { get; set; }
        [ScaffoldColumn(false)]

        [Required(ErrorMessage = "O campo 'Código' é obrigatório.")]
        public string Codigo { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        [ScaffoldColumn(false)]
        public Guid VeiculoId { get; set; }
        [ScaffoldColumn(false)]
        public Guid EmpresaId { get; set; }
        public IEnumerable<RegistroSaidaViewModel> RegistroSaida { get; set; }

        public EmpresaViewModel Empresa { get; set; }

        public VeiculoViewModel Veiculo { get; set; }

    }
}
