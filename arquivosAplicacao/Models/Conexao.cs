using Microsoft.EntityFrameworkCore;

namespace CadastroComApi.Models
{
    public class Conexao : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString: @"server=localhost; Initial Catalog=CadastroComApi; uid=root; pwd=1234",
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-msql"));
        }
    }
}
