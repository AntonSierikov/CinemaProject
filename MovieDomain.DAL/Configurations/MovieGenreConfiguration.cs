using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MovieDomain.DAL.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {

        //----------------------------------------------------------------//

        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(m => new { m.MovieId, m.GenreId });

            //PK
            builder.HasOne(mg => mg.Movie)
                   .WithMany(m => m.Genres)
                   .HasForeignKey(m => m.MovieId)
                   .IsRequired(true);

            builder.HasOne(mg => mg.Genre)
                   .WithMany(g => g.Movies)
                   .HasForeignKey(m => m.GenreId)
                   .IsRequired(true);
        }

        //----------------------------------------------------------------//

    }
}
