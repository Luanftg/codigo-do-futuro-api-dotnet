

using cdf_api_integrador.Models;

using cdf_api_integrador.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class ClientRepositoryEntity : IRepository<Cliente>
{
    private ContextEntity context;
    public ClientRepositoryEntity()
    {
        context = new ContextEntity();
    }

    public async Task<List<Cliente>> TodosAsync()
    {
        return await context.Clientes.ToListAsync();
    }

    public async Task IncluirAsync(Cliente loja)
    {
        context.Clientes.Add(loja);
        await context.SaveChangesAsync();
    }

    public async Task<Cliente> AtualizarAsync(Cliente loja)
    {
        context.Entry(loja).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return loja;
    }

    public async Task ApagarAsync(Cliente loja)
    {
        var obj = await context.Clientes.FindAsync(loja.Id);
        if(obj is null) throw new Exception("Cliente não encontrado");
        context.Clientes.Remove(obj);
        await context.SaveChangesAsync();
    }
}