
using cdf_api_integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class ContextEntity : DbContext
{

    public ContextEntity() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conexao = Environment.GetEnvironmentVariable("DATABASE_CDF");
        if(conexao == null) conexao = "Server=localhost;Database=api_cdf-radar;Uid=root;Pwd=INCLUIR SUA SENHA;";
        optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
    }

    public DbSet<Cliente> Clientes { get; set; } = default!;
    public DbSet<Produto> Produtos { get; set; } = default!;
    public DbSet<Campanha> Campanhas { get; set; } = default!;
    public DbSet<Cliente> Veiculos { get; set; } = default!;
    public DbSet<Endereco> Enderecos { get; set; } = default!;
    public DbSet<Loja> Lojas { get; set; } = default!;
    public DbSet<Pedido> Pedidos { get; set; } = default!;
    public DbSet<PedidoProduto> PedidosProdutos { get; set; } = default!;
    public DbSet<PosicoesProduto> PosicoesProdutos { get; set; } = default!;
    public DbSet<Usuario> Usuarios { get; set; } = default!;
} 