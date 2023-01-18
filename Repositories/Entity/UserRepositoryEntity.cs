
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace cdf_api_integrador.Repositories.Entity;

public class UserRepositoryEntity : IRepositoryUser<Usuario>
{
    private ContextEntity context;
    public UserRepositoryEntity()
    {
        context = new ContextEntity();
    }

    //private string? conexao = null;

    public async Task<List<Usuario>> TodosAsync()
    {
        return await context.Usuarios.ToListAsync();
    }

    public async Task<Usuario?> Login(string email, string senha)
    {
        return await context.Usuarios.Where(a => a.Email == email && a.Senha == senha).FirstOrDefaultAsync();
    }

    public async Task IncluirAsync(Usuario usuario)
    {
        context.Usuarios.Add(usuario);
        await context.SaveChangesAsync();
    }

    public async Task<Usuario> AtualizarAsync(Usuario usuario)
    {

        context.Entry(usuario).State = EntityState.Modified;
        await context.SaveChangesAsync();   
        return usuario;
    }

    public async Task ApagarAsync(Usuario usuarios)
    {
        var obj = await context.Usuarios.FindAsync(usuarios.Id);
        if(obj is null) throw new Exception("Usuario não encontrado");
        context.Usuarios.Remove(obj);
        await context.SaveChangesAsync();
    }
}

