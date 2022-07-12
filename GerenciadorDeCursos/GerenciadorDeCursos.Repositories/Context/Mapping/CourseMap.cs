using GerenciadorDeCursos.Border.Entities.CourseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDeCursos.Repositories.Context.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.Property(p => p.Title).HasMaxLength(20).IsRequired();
            builder.Property(p => p.InitialData).IsRequired();
            builder.Property(p => p.FinalData).IsRequired();
            builder.Property(p => p.Status).HasConversion<string>().IsRequired();

            builder.HasMany(p => p.Students)
                    .WithMany(p => p.EnrolledCourses);
        }
    }
}