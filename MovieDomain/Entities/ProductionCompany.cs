using System.Collections.Generic;
using MovieDomain.Abstract;
using MovieDomain.ComparerFactories;

namespace MovieDomain.Entities
{
    public partial class ProductionCompany : DbObject<int>
    {
        public ProductionCompany()
        {
            Movies = new HashSet<Movie>(EqualityComparerFactory.BaseDbIntPKComparer);
        }

        public HashSet<Movie> Movies { get; set; }

        //----------------------------------------------------------------//

        public ProductionCompany(string name)
        {
            Name = name;
        }

        //----------------------------------------------------------------//

        public string Name { get; set; }

        //public string Parent_Company { get; set; }

        //public string Description { get; set; }

        //public string Headquaters { get; set; }

        //public string Origin_Country { get; set; }

        //----------------------------------------------------------------//

    }
}
