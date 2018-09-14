using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieDomain.DAL.Configurations
{
    class ProductionCountryConfiguration : IEntityTypeConfiguration<ProductionCountry>
    {
        private const string COUNTRY_PK_NAME = "CountryId";

        //----------------------------------------------------------------//
        public void Configure(EntityTypeBuilder<ProductionCountry> builder)
        {
            //Ignore
            builder.Ignore(p => p.Movies);

            builder.Property(p => p.Id).HasColumnName(COUNTRY_PK_NAME);
            builder.HasKey(p => p.Id);
        }

        //----------------------------------------------------------------//

    }
}
