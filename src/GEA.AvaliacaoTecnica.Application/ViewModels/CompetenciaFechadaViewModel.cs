using System;
using System.ComponentModel.DataAnnotations;

namespace GEA.AvaliacaoTecnica.Application.ViewModels
{
    public class CompetenciaFechadaViewModel
    {
        public CompetenciaFechadaViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public float ValorBruto { get; set; }
        public float ValorLucro { get; set; }
        public Guid CompetenciaAbertaId { get; set; }
        public CompetenciaAberturaViewModel CompetenciaAberta { get; set; }
    }
}

