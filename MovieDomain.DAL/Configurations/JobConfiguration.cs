using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieDomain.DAL.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public const string JOB_PK_NAME = "JobId";

        //----------------------------------------------------------------//

        public void Configure(EntityTypeBuilder<Job> builder)
        {

            builder.Property(j => j.Id).HasColumnName(JOB_PK_NAME);
            builder.HasKey(j => j.Id);

            builder.HasOne(j => j.Department)
                   .WithMany(d => d.Jobs)
                   .HasForeignKey(j => j.DepartmentId);
        }

        //----------------------------------------------------------------//

    }
}
