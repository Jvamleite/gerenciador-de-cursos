using GerenciadorDeCursos.Border.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDeCursos.Repositories.Context.Mapping
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasAlternateKey(p => p.RegistrationNumber);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.Username).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.CPF).IsRequired();

            builder.HasMany(p => p.EnrolledCourses)
                .WithMany(p => p.Students);
            builder.HasOne(p => p.Role)
                .WithMany(p => p.Student);
        }
    }
}