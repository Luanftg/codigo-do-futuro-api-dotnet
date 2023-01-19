

using cdf_api_integrador.Models;

using cdf_api_integrador.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class OrderRepositoryEntity : IRepository<Pedido>
{
    private ContextEntity context;
    public OrderRepositoryEntity()
    {
        context = new ContextEntity();
    }

    public async Task<List<Pedido>> TodosAsync()
    {
        return await context.Pedidos.ToListAsync();
    }

    public async Task IncluirAsync(Pedido pedido)
    {
        context.Pedidos.Add(pedido);
        await context.SaveChangesAsync();
    }

    public async Task<Pedido> AtualizarAsync(Pedido pedido)
    {
        context.Entry(pedido).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return pedido;
    }

    public async Task ApagarAsync(Pedido pedido)
    {
        var obj = await context.Pedidos.FindAsync(pedido.Id);
        if(obj is null) throw new Exception("Pedido não encontrado");
        context.Pedidos.Remove(obj);
        await context.SaveChangesAsync();
    }
}