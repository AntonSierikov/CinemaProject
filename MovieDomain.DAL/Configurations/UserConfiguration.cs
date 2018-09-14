using MovieDomain.AuthEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieDomain.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        //----------------------------------------------------------------//
        public void Configure(EntityTypeBuilder<User> builder)
        {

        }

        //----------------------------------------------------------------//

    }
}
