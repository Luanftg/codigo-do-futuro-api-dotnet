


namespace cdf_api_integrador.Repositories.Interface;

public interface IRepositoryUser<T> : IRepository<T>
{
    Task<T?> Login(string email, string senha);
}