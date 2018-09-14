using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MovieDomain.DAL.Configurations
{
    public class ProductionCompanyConfiguration : IEntityTypeConfiguration<ProductionCompany>
    {
        private const string COMPANY_PK_NAME = "CompanyId";

        //----------------------------------------------------------------//

        public void Configure(EntityTypeBuilder<ProductionCompany> builder)
        {
            builder.Ignore(p => p.Movies);
            builder.Property(p => p.Id).HasColumnName(COMPANY_PK_NAME);

            builder.HasKey(p => p.Id);
        }

        //----------------------------------------------------------------//

    }
}
