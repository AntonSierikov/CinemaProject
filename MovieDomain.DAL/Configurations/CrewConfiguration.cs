using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MovieDomain.DAL.Configurations
{
    public class CrewConfiguration : IEntityTypeConfiguration<Crew>
    {
        public string CREW_PK_NAME = "CrewId";

        //----------------------------------------------------------------//
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.Property(c => c.Id).HasColumnName(CREW_PK_NAME);
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Job);
            builder.HasOne(c => c.Movie);
            builder.HasOne(c => c.People);
                
        }

        //----------------------------------------------------------------//

    }
}
