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

    public async Task IncluirAsync(Cliente cliente)
    {
        context.Clientes.Add(cliente);
        await context.SaveChangesAsync();
    }

    public async Task<Cliente> AtualizarAsync(Cliente cliente)
    {
        context.Entry(cliente).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return cliente;
    }

    public async Task ApagarAsync(Cliente cliente)
    {
        var obj = await context.Clientes.FindAsync(cliente.Id);
        if(obj is null) throw new Exception("Cliente não encontrado");
        context.Clientes.Remove(obj);
        await context.SaveChangesAsync();
    }
}