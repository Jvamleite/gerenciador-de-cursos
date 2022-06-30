using Bogus;

namespace GerenciadorDeCursos.Tests.Utils
{
    public class FakerPtBr
    {
        public static Faker CreateFaker() => new Faker("pt_BR");
    }
}
