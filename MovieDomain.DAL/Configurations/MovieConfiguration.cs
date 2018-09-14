using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MovieDomain.DAL.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        private const string MOVIE_PK_NAME = "MovieId";

        //----------------------------------------------------------------//

        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            //Ignore
            builder.Ignore(m => m.Genres);
            builder.Ignore(m => m.ProductionCompanies);
            builder.Ignore(m => m.ProductionCountries);
            builder.Ignore(m => m.Liked);
            builder.Ignore(m => m.WillWatch);
            builder.Ignore(m => m.Appreciated);
            builder.Ignore(m => m.Comments);

            builder.HasKey(m => m.Id);
            builder.Property(c => c.Id).HasColumnName(MOVIE_PK_NAME);
            builder.Property(m => m.Id).UseSqlServerIdentityColumn();

            builder.HasMany(m => m.Casts)
                   .WithOne(c => c.Movie)
                   .HasForeignKey(c => c.MovieId)
                   .IsRequired(true);

            builder.HasMany(m => m.Crews)
                   .WithOne(m => m.Movie)
                   .HasForeignKey(c => c.MovieId)
                   .IsRequired(true);
        }

        //----------------------------------------------------------------//

    }
}
