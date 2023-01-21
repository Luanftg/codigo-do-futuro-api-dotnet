using cdf_api_integrador.Models;

using cdf_api_integrador.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class OrderProductRepositoryEntity : IRepository<PedidoProduto>
{
    private ContextEntity context;
    public OrderProductRepositoryEntity()
    {
        context = new ContextEntity();
    }

    public async Task<List<PedidoProduto>> TodosAsync()
    {
        return await context.PedidosProdutos.Include(p=>p.Pedido).Include(p=>p.Produto).ToListAsync();
    }

    public async Task IncluirAsync(PedidoProduto pedidoProduto)
    {
        context.PedidosProdutos.Add(pedidoProduto);
        await context.SaveChangesAsync();
    }

    public async Task<PedidoProduto> AtualizarAsync(PedidoProduto pedidoProduto)
    {
        context.Entry(pedidoProduto).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return pedidoProduto;
    }

    public async Task ApagarAsync(PedidoProduto pedidoProduto)
    {
        var obj = await context.PedidosProdutos.FindAsync(pedidoProduto.Id);
        if(obj is null) throw new Exception("PedidoProduto não encontrado");
        context.PedidosProdutos.Remove(obj);
        await context.SaveChangesAsync();
    }
}