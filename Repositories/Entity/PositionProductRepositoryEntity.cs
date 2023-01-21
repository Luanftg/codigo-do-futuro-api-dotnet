using cdf_api_integrador.Models;

using cdf_api_integrador.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class PositionProductRepositoryEntity : IRepository<PosicoesProduto>
{
    private ContextEntity context;
    public PositionProductRepositoryEntity()
    {
        context = new ContextEntity();
    }

    public async Task<List<PosicoesProduto>> TodosAsync()
    {
        return await context.PosicoesProdutos.Include(p=>p.Campanha).Include(p=>p.Produto).ToListAsync();
    }

    public async Task IncluirAsync(PosicoesProduto posicoesProduto)
    {
        context.PosicoesProdutos.Add(posicoesProduto);
        await context.SaveChangesAsync();
    }

    public async Task<PosicoesProduto> AtualizarAsync(PosicoesProduto posicoesProduto)
    {
        context.Entry(posicoesProduto).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return posicoesProduto;
    }

    public async Task ApagarAsync(PosicoesProduto posicoesProduto)
    {
        var obj = await context.PosicoesProdutos.FindAsync(posicoesProduto.Id);
        if(obj is null) throw new Exception("PosicoesProduto não encontrado");
        context.PosicoesProdutos.Remove(obj);
        await context.SaveChangesAsync();
    }
}