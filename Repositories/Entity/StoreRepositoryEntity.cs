

using cdf_api_integrador.Models;

using cdf_api_integrador.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class StoreRepositoryEntity : IRepository<Loja>
{
    private ContextEntity context;
    public StoreRepositoryEntity()
    {
        context = new ContextEntity();
    }

    public async Task<List<Loja>> TodosAsync()
    {
        return await context.Lojas.ToListAsync();
    }

    public async Task IncluirAsync(Loja loja)
    {
        context.Lojas.Add(loja);
        await context.SaveChangesAsync();
    }

    public async Task<Loja> AtualizarAsync(Loja loja)
    {
        context.Entry(loja).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return loja;
    }

    public async Task ApagarAsync(Loja loja)
    {
        var obj = await context.Lojas.FindAsync(loja.Id);
        if(obj is null) throw new Exception("Loja não encontrado");
        context.Lojas.Remove(obj);
        await context.SaveChangesAsync();
    }
}