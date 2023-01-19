using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class ProductRepositoryEntity : IRepository<Produto>
{
    private ContextEntity context;
    public ProductRepositoryEntity()
    {
        context = new ContextEntity();
    }

    public async Task<List<Produto>> TodosAsync()
    {
        return await context.Produtos.ToListAsync();
    }

    public async Task IncluirAsync(Produto produto)
    {
        context.Produtos.Add(produto);
        await context.SaveChangesAsync();
    }

    public async Task<Produto> AtualizarAsync(Produto produto)
    {
        context.Entry(produto).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return produto;
    }

    public async Task ApagarAsync(Produto produto)
    {
        var obj = await context.Produtos.FindAsync(produto.Id);
        if(obj is null) throw new Exception("Produto não encontrado");
        context.Produtos.Remove(obj);
        await context.SaveChangesAsync();
    }
}