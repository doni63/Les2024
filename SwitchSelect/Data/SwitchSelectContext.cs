using Microsoft.EntityFrameworkCore;
using SwitchSelect.Models;
using SwitchSelect.Models.Endereco;
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

public DbSet<SwitchSelect.Models.ViewModels.ClienteViewModel> ClienteViewModel { get; set; } = default!;
    

    

}
