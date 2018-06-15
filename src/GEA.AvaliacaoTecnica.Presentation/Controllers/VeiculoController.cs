using GEA.AvaliacaoTecnica.Application.Interfaces;
using GEA.AvaliacaoTecnica.Application.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace GEA.AvaliacaoTecnica.Presentation.Controllers
{
    [Authorize]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoAppService _veiculoAppSerice;
        public VeiculoController(IVeiculoAppService veiculoAppSerice)
        {
            _veiculoAppSerice = veiculoAppSerice;
        }

        public ActionResult Index()
        {
            
            return View(_veiculoAppSerice.ObterTodos().OrderByDescending(e => e.DataCadastro));
        }

        public ActionResult Cadastrar()
        {

            VeiculoViewModel veiculoViewMode = new VeiculoViewModel();
            return View(veiculoViewMode);
        }
        [HttpPost]
        public ActionResult Cadastrar(VeiculoViewModel veiculoViewModel)
        {
            if(_veiculoAppSerice.ObterPorPlaca(veiculoViewModel.Placa).Count() > 0)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMensager = "Veículo já registrada no sistema.";
                return View();
            }
            _veiculoAppSerice.Adicionar(veiculoViewModel);
            return RedirectToAction("Index", "Veiculo");
        }
    }
}