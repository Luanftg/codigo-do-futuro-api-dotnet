
namespace cdf_api_integrador.Repositories.Interface;

public interface IRepository<T>
{
    Task<List<T>> TodosAsync();
    Task IncluirAsync(T obj);
    Task<T> AtualizarAsync(T obj);
    Task ApagarAsync(T obj);
}