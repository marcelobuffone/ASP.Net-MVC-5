using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GEA.AvaliacaoTecnica.Application.ViewModels
{
    public class CompetenciaAberturaViewModel
    {
        public CompetenciaAberturaViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        public DateTime DataVencimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid EmpresaId { get; set; }
        public EmpresaViewModel Empresa { get; set; }
        public IEnumerable<CompetenciaFechadaViewModel> CompetenciasFechadas { get; set; }
        public IEnumerable<RegistroEmailViewModel> RegistrosEmails { get; set; }
        public CompetenciaFechadaViewModel CompetenciasFechada { get; set; }
    }
}
