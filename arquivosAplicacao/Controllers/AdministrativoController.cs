using CadastroComApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroComApi.Controllers
{
    public class AdministrativoController : Controller
    {
        private readonly Conexao db;
        public AdministrativoController(Conexao contexto)
        {
            db = contexto;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
