using cdf_api_integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class ContextEntity : DbContext
{

    public ContextEntity() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conexao = Environment.GetEnvironmentVariable("DATABASE_CDF");
        if(conexao == null) conexao = "Server=localhost;Database=api_cdf-radar;Uid=root;Pwd=Luan_17101988;";
        optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
    }

    public DbSet<Campanha> Produtos { get; set; } = default!;
    public DbSet<Cliente> Veiculos { get; set; } = default!;
    public DbSet<Endereco> Enderecos { get; set; } = default!;
    public DbSet<Loja> Loja { get; set; } = default!;
    public DbSet<Pedido> Pedido { get; set; } = default!;
    public DbSet<PedidoProduto> PedidoProduto { get; set; } = default!;
    public DbSet<PosicoesProduto> PosicoesProduto { get; set; } = default!;
    public DbSet<Usuario> Usuarios { get; set; } = default!;
} 