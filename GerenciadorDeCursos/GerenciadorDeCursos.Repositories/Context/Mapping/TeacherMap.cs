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
            builder.Property(p => p.Username).IsRequired();
            builder.Property(p => p.Password).IsRequired();

            builder.HasMany(p => p.Courses)
                .WithOne(p => p.Teacher).HasForeignKey(p => p.TeacherId);
        }
    }
}