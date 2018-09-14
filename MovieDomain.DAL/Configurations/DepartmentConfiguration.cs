using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MovieDomain.DAL.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public string DEPARTMENT_PK_NAME = "DepartmentId";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).HasColumnName(DEPARTMENT_PK_NAME);
            builder.HasKey(d => d.Id);

            builder.HasMany(d => d.Jobs)
                   .WithOne(j => j.Department)
                   .HasForeignKey(j => j.DepartmentId)
                   .HasPrincipalKey(d => d.Id)
                   .IsRequired(true);
        }
    }
}
