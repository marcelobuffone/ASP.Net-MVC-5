using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Application.ViewModels
{
    public class NovoRegistroEmailViewModel
    {
        public Guid Id { get; set; }
        public IEnumerable<RegistroEmailViewModel> registrosEmails { get; set; }
        public RegistroEmailViewModel RegistroEmail { get; set; }
    }
}
