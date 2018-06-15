using GEA.AvaliacaoTecnica.Application.Interfaces;
using GEA.AvaliacaoTecnica.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GEA.AvaliacaoTecnica.Presentation.Controllers
{
    public class RegistroEmailController : Controller
    {
        private readonly IRegistroEmailAppService _registroEmailAppSerice;
        public RegistroEmailController(IRegistroEmailAppService registroEmailAppSerice)
        {
            _registroEmailAppSerice = registroEmailAppSerice;
        }

        [Route("Historico/{id}")]
        public ActionResult Historico(Guid id)
        {
            var registrosEmails = new NovoRegistroEmailViewModel
            {
                Id = id,
                registrosEmails = _registroEmailAppSerice.ObterPorCompetenciaAbertaId(id)
            };
            return View(registrosEmails);
        }

        public ActionResult Novo(Guid id)
        {
            var registroEmail = new NovoRegistroEmailViewModel
            {
                Id = id
            };
            return View(registroEmail);
        }

        public ActionResult Enviar(NovoRegistroEmailViewModel novoRegistroEmail)
        {
            novoRegistroEmail.RegistroEmail.CompetenciaAbertaId = novoRegistroEmail.Id;
            _registroEmailAppSerice.Adicionar(novoRegistroEmail.RegistroEmail);
            return RedirectToAction("Historico", new { id = novoRegistroEmail.Id });
        }
    }
}