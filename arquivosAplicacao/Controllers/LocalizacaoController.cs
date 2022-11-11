using CadastroComApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CadastroComApi.Controllers
{
    public class LocalizacaoController : Controller
    {
        private readonly Conexao db;
        public LocalizacaoController(Conexao contexco)
        {
            db = contexco;
        }

        public async Task<IActionResult> Index(string query)
        {
            try
            {  
                if(query == null)
                {
                    var urlLocalizacao = "https://localhost:7094/api/Localizacaos"; // Url da Api
                    HttpClient client = new HttpClient();
                    var response = await client.GetStringAsync(urlLocalizacao);
                    var locais = JsonConvert.DeserializeObject<List<ApiLocal>>(response);

                    return View(locais);
                }
                else
                {
                    var urlLocalizacao = $"https://localhost:7094/WeatherForecast/{query}"; // Url da Api
                    HttpClient client = new HttpClient();
                    var response = await client.GetStringAsync(urlLocalizacao);
                    var locais = JsonConvert.DeserializeObject<List<ApiLocal>>(response);

                    return View(locais);
                }

            }
            catch
            {
                TempData["erroAoCarregar"] = "Ocorreu um erro. Tente novamente em instantes.";
                return RedirectToAction("index", "Administrativo");
            }
        }
    }
}
