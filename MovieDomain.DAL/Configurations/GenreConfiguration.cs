using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieDomain.DAL.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {

        private const string GENRE_PK_NAME = "GenreId";

        //----------------------------------------------------------------//

        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(g => g.Id).HasColumnName(GENRE_PK_NAME);
            builder.HasKey(g => g.Id);

            builder.Ignore(g => g.Movies);

            //----------------------------------------------------------------//
            //Configure properties
            builder.Property(g => g.genre)
                   .HasMaxLength(20);
        }

        //----------------------------------------------------------------//


    }
}
