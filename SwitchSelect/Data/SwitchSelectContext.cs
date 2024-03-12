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
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurações de Cliente-Endereco
        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Enderecos)
            .WithOne(e => e.Cliente)
            .HasForeignKey(e => e.ClienteId);

        // Configurações de Endereco-Bairro
        modelBuilder.Entity<Endereco>()
            .HasOne(e => e.Bairro)
            .WithMany() // Se Bairro não tiver uma coleção de Enderecos
            .HasForeignKey(e => e.BairroId);

        // Configurações de Bairro-Cidade
        modelBuilder.Entity<Bairro>()
            .HasOne(b => b.Cidade)
            .WithMany() // Se Cidade não tiver uma coleção de Bairros
            .HasForeignKey(b => b.CidadeId);

        // Configurações de Cidade-Estado
        modelBuilder.Entity<Cidade>()
            .HasOne(c => c.Estado)
            .WithMany() // Se Estado não tiver uma coleção de Cidades
            .HasForeignKey(c => c.EstadoId);
    }

}
