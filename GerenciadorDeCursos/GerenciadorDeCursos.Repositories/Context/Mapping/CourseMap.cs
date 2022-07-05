using GerenciadorDeCursos.Border.Entities.CourseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDeCursos.Repositories.Context.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Cursos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Título).HasMaxLength(20).IsRequired();
            builder.Property(p => p.DataInicial).IsRequired();
            builder.Property(p => p.DataFinal).IsRequired();
            builder.Property(p => p.Status).HasConversion<string>().IsRequired();

            builder.HasMany(p => p.Students)
                    .WithMany(p => p.EnrolledCourses);
        }
    }
}