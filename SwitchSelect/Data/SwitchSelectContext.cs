using Microsoft.EntityFrameworkCore;
using SwitchSelect.Models;
using SwitchSelect.Models.Endereco;


namespace SwitchSelect.Data;

public class SwitchSelectContext : DbContext
{
    public SwitchSelectContext(DbContextOptions<SwitchSelectContext> options)
        : base(options)
    {

    }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Jogo> Jogos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<LogradouroModel> Logradouros { get; set; }
    public DbSet<Bairro> Bairros { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Estado> Estados { get; set; }

    

}
