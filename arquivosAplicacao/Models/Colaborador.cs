namespace CadastroComApi.Models
{
    public class Colaborador
    {
        public int Id { get; set; } 
        public string NomeCompleto { get; set; }
        public int Idade { get; set; }
        public string EstadoCivil { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ddd { get; set; }
        public int UsuarioId { get; set; }
        
    }
}
