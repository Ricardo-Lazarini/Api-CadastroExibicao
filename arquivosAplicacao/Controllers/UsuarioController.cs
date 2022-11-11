using CadastroComApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CadastroComApi.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Conexao db;
        public UsuarioController(Conexao contexto)
        {
            db = contexto;
        }

        // Exibe a tela principal dos usuarios. Mostra as contas criadas
        public IActionResult Index(string? query)
        {
            if(query == null)
            {
                 return View(db.Usuarios.ToList());
            }
            else
            {
                return View(db.Usuarios.Where(a => a.Email == query));
            }
        }


        // Recebe dados preenchidos no form de criação de conta
        [HttpPost]
        public ActionResult CriarContaUsuario(Usuario collection)
        {
            try
            {
                db.Usuarios.Add(collection);
                db.SaveChanges();
                TempData["msgAlert"] = "Cadastro efetuado com sucesso. Você já pode acessar o sistema.";
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                TempData["msgAlert"] = "Algo deu errado.  Não foi possível realizar seu cadastro.";
                return RedirectToAction("Index", "Login");
            }
        }


        // Verifica se o usuario existe, se senha e login conferem, e se sim, envia para a pagina administrativa do sistema.
        public ActionResult Logar(string email, string senha)
        {
            var usuarioLogado = db.Usuarios.Where(a => a.Email == email && a.Senha == senha).FirstOrDefault();
            if(usuarioLogado != null)
            {
                return RedirectToAction("Index", "Administrativo");
            }
            else
            {
                TempData["msg"] = "Email ou senha invalido.";
                return RedirectToAction("Index","Login");
            }
        }


        // Exibe a pagina para cadastro completo do Usuario
        // Pega os dados de localização fornecidos pela API ViaCep
        public async Task<IActionResult> CadastroColaboradores(int id, string cep)
        {
            // Pega o id que esta vindo e pesquisa na tabela de colaboradores se o usuario tem um cadastro completo. Caso tenha, envia para a view de edição de colaboradores, caso nao, para a view de cadastro de colaboradores.
            var userExiste = db.Colaboradores.Where(a => a.UsuarioId == id).FirstOrDefault();
            if (userExiste == null)
            {
                var c = "";

                if (cep == null)
                {
                    c = "00000000";
                }
                else
                {
                    c = cep;
                }
                var urlViaCep = $"https://viacep.com.br/ws/{c}/json/";
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(urlViaCep);
                var responseConvert = JsonConvert.DeserializeObject<Localizacao>(response);

                Localizacao dados = new Localizacao();
                dados.localizacao = responseConvert;
                dados.UsuarioId = id;

                return View(dados);
            }
            else
            {
                return RedirectToAction( "EditarColaborador", db.Colaboradores.Where(a => a.UsuarioId == id).FirstOrDefault());
            }

        }


        // Cria um cadastro mais completo do colaborador(Usuario)
        [HttpPost]
        public ActionResult createColaborador(Colaborador collection)
        {
            try
            {
                db.Colaboradores.Add(collection);
                db.SaveChanges();
                TempData["erro"] = "Sucesso";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["erro"] = "Errado";
                return RedirectToAction("Index", "Administrativo");
            }

        }


        // Abre pagina de Edições do colaborabor
        public IActionResult EditarColaborador(int id)
        {
            return View(db.Colaboradores.Where(a => a.Id == id).FirstOrDefault());
        }

        // Eclui colaborador
        public ActionResult ExcluirColaborador(int id , Usuario  collection)
        {
            try
            {
                db.Usuarios.Remove(collection);
                db.SaveChanges();
                TempData["msgEclusao"] = "Usuario excluido com sucesso !";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["msgEclusao"] = "Não foi possível excluir este usuario";
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
