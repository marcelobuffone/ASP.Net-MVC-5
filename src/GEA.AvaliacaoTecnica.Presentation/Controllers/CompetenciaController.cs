using GEA.AvaliacaoTecnica.Application.Interfaces;
using GEA.AvaliacaoTecnica.Application.ViewModels;
using GEA.AvaliacaoTecnica.Infra.CrossCutting.MvcFilters;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GEA.AvaliacaoTecnica.Presentation.Controllers
{
    [MyAuthorize(Roles = "Admin")]
    public class CompetenciaController : Controller
    {
        private readonly ICompetenciaAbertaAppService _competenciaAbertaAppService;
        private readonly ICompetenciaFechadaAppService _competenciaFechadaAppService;
        private readonly IRegistroSaidaAppService _registroSaidaAppService;
        public CompetenciaController(ICompetenciaAbertaAppService competenciaAbertaAppService
                                     , ICompetenciaFechadaAppService competenciaFechadaAppService
                                     , IRegistroSaidaAppService registroSaidaAppService)
        {
            _competenciaAbertaAppService = competenciaAbertaAppService;
            _competenciaFechadaAppService = competenciaFechadaAppService;
            _registroSaidaAppService = registroSaidaAppService;
        }

        public ActionResult Abertas()
        {
            return View(_competenciaAbertaAppService.ObterTodos().OrderByDescending(e => e.DataVencimento));
        }
        public ActionResult Fechadas()
        {
            return View(_competenciaFechadaAppService.ObterTodos().OrderByDescending(e => e.DataCadastro));
        }

        //[Route("Competencia/Encerrar/{id}")]
        //public ActionResult Encerrar(Guid id)
        //{
        //    var competenciaAberta = _competenciaAbertaAppService.ObterPorId(id);
        //    if (competenciaAberta == null)
        //        return HttpNotFound();

        //    competenciaAberta.CompetenciasFechadas
        //        .ToList()
        //        .Add(EncerrarCompetenciaAberta(competenciaAberta));

        //    _competenciaFechadaAppService.Adicionar(EncerrarCompetenciaAberta(competenciaAberta));
        //    var novaCompetenciaAberta = new CompetenciaAberturaViewModel
        //    {
        //        DataVencimento = competenciaAberta.DataVencimento.AddMonths(1),
        //        EmpresaId = competenciaAberta.EmpresaId
        //    };
        //    _competenciaAbertaAppService.Adicionar(novaCompetenciaAberta);
        //    return View();
        //}

        [Route("Competencia/ConfirmarFechamento/{id}")]
        public ActionResult ConfirmarFechamento(Guid id)
        {
            var competenciaAberta = _competenciaAbertaAppService.ObterPorId(id);
            if (competenciaAberta == null)
                return HttpNotFound();

            competenciaAberta.CompetenciasFechada = EncerrarCompetenciaAberta(competenciaAberta);

            return View(competenciaAberta);
        }

        public ActionResult Encerrar(CompetenciaAberturaViewModel competenciaAbertaId)
        {
            var competenciaAberta = _competenciaAbertaAppService.ObterPorId(competenciaAbertaId.Id);
            if (competenciaAberta == null)
                return HttpNotFound();

            competenciaAberta.CompetenciasFechada = EncerrarCompetenciaAberta(competenciaAberta);

            _competenciaFechadaAppService.Adicionar(competenciaAberta.CompetenciasFechada);
            var novaCompetenciaAberta = new CompetenciaAberturaViewModel
            {
                DataVencimento = competenciaAberta.DataVencimento.AddMonths(1),
                EmpresaId = competenciaAberta.EmpresaId
            };
            _competenciaAbertaAppService.Adicionar(novaCompetenciaAberta);
            return RedirectToAction("Fechadas");
        }

        private CompetenciaFechadaViewModel EncerrarCompetenciaAberta(CompetenciaAberturaViewModel competenciaAberta)
        {

            var valorTotalBruto = Convert.ToSingle(_registroSaidaAppService.ObterTotalBruto(competenciaAberta.DataVencimento, competenciaAberta.EmpresaId).ToString("0.00"));
            float valorLucro = Convert.ToSingle(valorTotalBruto * 0.05);
            var competenciaFechada = new CompetenciaFechadaViewModel
            {
                ValorBruto = valorTotalBruto,
                ValorLucro = Convert.ToSingle(valorLucro.ToString("0.00")),
                CompetenciaAbertaId = competenciaAberta.Id
            };
            return competenciaFechada;
        }



    }
}