namespace GerenciadorDeCursos.Border.Shared
{
    public interface IRepository<TRequest, TResponse>
    {
        TResponse AddAsync(TRequest request);
    }
}