using GEA.AvaliacaoTecnica.Application.Interfaces;
using GEA.AvaliacaoTecnica.Infra.CrossCutting.MvcFilters;
using System.Linq;
using System.Web.Mvc;

namespace GEA.AvaliacaoTecnica.Presentation.Controllers
{
    [MyAuthorize(Roles = "Admin")]
    public class OperarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IEmpresaAppService _empresaAppService;

        public OperarioController(IUsuarioAppService usuarioAppService
                                  , IEmpresaAppService empresaAppService)
        {
            _usuarioAppService = usuarioAppService;
            _empresaAppService = empresaAppService;
        }
        public ActionResult Index()
        {
            
            return View(_usuarioAppService.ObterTodos().OrderBy(e => e.EmpresaId));
        }

        //public ActionResult Cadastrar()
        //{

        //    var model = new UserRegisterViewModel
        //    {
        //        Empresas = _empresaAppService.ObterTodos()
        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Cadastrar(UserRegisterViewModel userRegister)
        //{
        //    //ViewBag.SuccessMessage = "<p>Success!</p>";
        //    userRegister.Usuario.EmpresaId = userRegister.EmpresaId;
        
        //    //util.VerificarRegistroIdentity(userRegister);
        //    _usuarioAppService.Adicionar(userRegister.Usuario);
            
        //    var model = new UserRegisterViewModel
        //    {
        //        Empresas = _empresaAppService.ObterTodos()
        //    };

        //    return View(model);
        //}
    }
}