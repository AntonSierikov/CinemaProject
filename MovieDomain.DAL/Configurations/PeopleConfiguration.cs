using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MovieDomain.DAL.Configurations
{
    public class PeopleConfiguration : IEntityTypeConfiguration<People>
    {
        private const string PEOPLE_PK_KEY = "PeopleId";

        //----------------------------------------------------------------//

        public void Configure(EntityTypeBuilder<People> builder)
        {

            //Ignore
            builder.Ignore(p => p.UsersWhoLiked);

            builder.Property(p => p.Id).HasColumnName(PEOPLE_PK_KEY);
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Casts)
                   .WithOne(c => c.People)
                   .IsRequired(false);

            builder.HasMany(p => p.Crews)
                   .WithOne(c => c.People)
                   .IsRequired(false);
        }

        //----------------------------------------------------------------//

    }
}
