using Microsoft.EntityFrameworkCore;
using SwitchSelect.Models;
using SwitchSelect.Models.ViewModels;


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
    public DbSet<Endereco> Enderecos { get; set; }

public DbSet<ClienteViewModel> ClienteViewModels { get; set; } = default!;
    

    

}
