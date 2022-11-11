/* Esta classe Contem os atributos da api ViaCep */

namespace CadastroComApi.Models
{
    public class Localizacao : Colaborador
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ddd { get; set; }
        public int UsuarioId { get; set; }
        public Localizacao localizacao { get; set; }

    }
}
