using CadastroComApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace CadastroComApi.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index(string? query)
        {
            var key = "neste espaco vai a chave fornecida pela api OpenWeather quando se cria a conta"; 
            var city = "";
            var lang = "pt_br";
            var rsc = Response.StatusCode; // Retorna o status 
            var erroNaConsulta = "";

            try
            {
                if (query != null)
                {
                    city = query;
                    erroNaConsulta =  "";
                }
                else
                {
                    city = "São Carlos";
                    erroNaConsulta = "inicio";
                }

                var urlOpenWeather = $"https://api.openweathermap.org/data/2.5/weather?q={city}&lang={lang}&appid={key}";
                HttpClient clima = new HttpClient();
                var response = await clima.GetStringAsync(urlOpenWeather);
                var urlConvert = JsonConvert.DeserializeObject<Clima>(response); 
                TempData["erroNaConsulta"] = erroNaConsulta;

                return View(urlConvert);
            }
            catch
            {
                var urlOpenWeather = $"https://api.openweathermap.org/data/2.5/weather?q={"São CArlos"}&appid={key}";
                HttpClient clima = new HttpClient();
                var response = await clima.GetStringAsync(urlOpenWeather);
                var urlConvert = JsonConvert.DeserializeObject<Clima>(response); // Transforma o que é texto em objeto

                erroNaConsulta = "Algo deu errado. Verifique a cidade e tente novamente.";
                TempData["erroNaConsulta"] = erroNaConsulta;

                return View(urlConvert);
            }
        }

    }
}

