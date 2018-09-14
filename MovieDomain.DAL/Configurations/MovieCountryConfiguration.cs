using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieDomain.DAL.Configurations
{
    public class MovieCountryConfiguration : IEntityTypeConfiguration<MovieCountry>
    {

        //----------------------------------------------------------------//

        public void Configure(EntityTypeBuilder<MovieCountry> builder)
        {
            builder.HasKey(m => new { m.CountryId, m.MovieId });

            builder.HasOne(m => m.Country)
                   .WithMany(c => c.Movies)
                   .HasForeignKey(m => m.CountryId)
                   .IsRequired(true);

            builder.HasOne(m => m.Movie)
                   .WithMany(c => c.ProductionCountries)
                   .HasForeignKey(m => m.MovieId)
                   .IsRequired(true);
        }

        //----------------------------------------------------------------//

    }
}
