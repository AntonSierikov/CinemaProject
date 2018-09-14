using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieDomain.DAL.Configurations
{
    public class MovieCompanyConfiguration : IEntityTypeConfiguration<MovieCompany>
    {

        //----------------------------------------------------------------//

        public void Configure(EntityTypeBuilder<MovieCompany> builder)
        {
            //PK
            builder.HasKey(m => new { m.CompanyId, m.MovieId });


            builder.HasOne(m => m.Company)
                   .WithMany(c => c.Movies)
                   .HasForeignKey(m => m.CompanyId)
                   .IsRequired(true);

            builder.HasOne(m => m.Movie)
                   .WithMany(c => c.ProductionCompanies)
                   .HasForeignKey(m => m.MovieId)
                   .IsRequired(true);
        }

        //----------------------------------------------------------------//

    }
}
