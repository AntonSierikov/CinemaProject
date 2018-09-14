using MovieDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieDomain.DAL.Configurations
{
    public class CastConfiguration : IEntityTypeConfiguration<Cast>
    {
        public const string CAST_PK_NAME = "CastId";

        //----------------------------------------------------------------//

        public void Configure(EntityTypeBuilder<Cast> builder)
        {
            builder.Property(c => c.Id).HasColumnName(CAST_PK_NAME);
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.People)
                   .WithMany(p => p.Casts)
                   .HasForeignKey(c => c.PeopleId)
                   .IsRequired(false);

            builder.HasOne(c => c.Movie)
                   .WithMany(m => m.Casts)
                   .HasForeignKey(c => c.Id)
                   .IsRequired(true);
        }

        //----------------------------------------------------------------//

    }
}
