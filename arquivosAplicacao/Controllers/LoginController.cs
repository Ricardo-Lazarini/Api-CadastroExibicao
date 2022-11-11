using Microsoft.AspNetCore.Mvc;

namespace CadastroComApi.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
