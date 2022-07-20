using GerenciadorDeCursos.Border.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDeCursos.Repositories.Context.Mapping
{
    public class TeacherMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.Username).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.CPF).IsRequired();

            builder.HasMany(p => p.Courses)
                .WithOne(p => p.Teacher);
            builder.HasOne(p => p.Role)
                .WithMany(p => p.Teacher);
        }
    }
}