using GerenciadorDeCursos.Border.Entities.Course;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDeCursos.Repositories.Context.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Título).HasMaxLength(20).IsRequired();
            builder.Property(p => p.DataInicial).IsRequired();
            builder.Property(p => p.DataFinal).IsRequired();
            builder.Property(p => p.Status).HasConversion<string>().IsRequired();
        }
    }
}