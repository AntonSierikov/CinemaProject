using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDomain.Entities;

namespace MovieDomain.DAL.Configurations
{
    public class TaskInfoConfiguration : IEntityTypeConfiguration<TaskInfo>
    {

        //----------------------------------------------------------------//

        public void Configure(EntityTypeBuilder<TaskInfo> builder)
        {
            builder.HasKey(t => t.Id);

        }

    }
}
