

using cdf_api_integrador.Models;

using cdf_api_integrador.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class CampainRepositoryEntity : IRepository<Campanha>
{
    private ContextEntity context;
    public CampainRepositoryEntity()
    {
        context = new ContextEntity();
    }

    public async Task<List<Campanha>> TodosAsync()
    {
        return await context.Campanhas.ToListAsync();
    }

    public async Task IncluirAsync(Campanha campanha)
    {
        context.Campanhas.Add(campanha);
        await context.SaveChangesAsync();
    }

    public async Task<Campanha> AtualizarAsync(Campanha campanha)
    {
        context.Entry(campanha).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return campanha;
    }

    public async Task ApagarAsync(Campanha campanha)
    {
        var obj = await context.Campanhas.FindAsync(campanha.Id);
        if(obj is null) throw new Exception("Campanha não encontrada");
        context.Campanhas.Remove(obj);
        await context.SaveChangesAsync();
    }
}