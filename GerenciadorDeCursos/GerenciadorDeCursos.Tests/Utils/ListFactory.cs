using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeCursos.Tests.Utils
{
    public static class ListFactory
    {
        public static List<T> Generate<T>(Func<T> factoryMethod, int min = default, int max = 5)
        {
            var faker = new Faker();

            return Enumerable.Range(default, faker.Random.Int(min, max))
                .Select(x => factoryMethod())
                .ToList();
        }
    }
}