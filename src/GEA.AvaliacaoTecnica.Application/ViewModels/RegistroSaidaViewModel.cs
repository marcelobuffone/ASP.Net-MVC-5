using System;

namespace GEA.AvaliacaoTecnica.Application.ViewModels
{
    public class RegistroSaidaViewModel
    {
        public RegistroSaidaViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime HoraSaida { get; set; }
        public float ValorTotal { get; set; }
        public Guid RegistroEntradaId { get; set; }
        public RegistroEntradaViewModel RegistroEntrada { get; set; }
    }
}
