using cdf_api_integrador.Models;

using cdf_api_integrador.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class AddressRepositoryEntity : IRepository<Endereco>
{
    private ContextEntity context;
    public AddressRepositoryEntity()
    {
        context = new ContextEntity();
    }

    public async Task<List<Endereco>> TodosAsync()
    {
        return await context.Enderecos.ToListAsync();
    }

    public async Task IncluirAsync(Endereco endereco)
    {
        context.Enderecos.Add(endereco);
        await context.SaveChangesAsync();
    }

    public async Task<Endereco> AtualizarAsync(Endereco endereco)
    {
        context.Entry(endereco).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return endereco;
    }

    public async Task ApagarAsync(Endereco endereco)
    {
        var obj = await context.Enderecos.FindAsync(endereco.Id);
        if(obj is null) throw new Exception("Endereco não encontrado");
        context.Enderecos.Remove(obj);
        await context.SaveChangesAsync();
    }
}