namespace GerenciadorDeCursos.Border.Shared
{
    public interface IRepository< in TRequest, out TResponse>
    {
        TResponse AddAsync(TRequest request);
    }
}