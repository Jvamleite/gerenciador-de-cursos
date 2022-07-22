using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Builders.CourseBuilder;
using GerenciadorDeCursos.Tests.Utils;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class TeacherResponseBuilderList
    {
        private readonly List<GetTeacherResponse> _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public TeacherResponseBuilderList()
        {
            _instance = ListFactory.Generate(() => new TeacherResponseBuilder().Build(), min: 2, max: 2);
            
        }

        public List<GetTeacherResponse> Build()
        {
            return _instance;
        }

        public TeacherResponseBuilderList WithListOfteacher(List<Teacher> teachers)
        {
            for (int i = 0; i < 2; i++)
            {
                _instance[i].Username = teachers[i].Username;
                _instance[i].Courses = teachers[i].Courses;
            }

            return this;
        }
    }
}