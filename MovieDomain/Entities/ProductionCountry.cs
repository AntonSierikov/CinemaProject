using System.Collections.Generic;
using MovieDomain.Abstract;
using MovieDomain.ComparerFactories;

namespace MovieDomain.Entities
{
    public partial class ProductionCountry : DbObject<int>
    {
        public ProductionCountry()
        {
            Movies = new HashSet<Movie>(EqualityComparerFactory.BaseDbIntPKComparer);
        }

        //----------------------------------------------------------------//

        public string iso_3166_1 { get; set; }

        public string Name { get; set; }

        public HashSet<Movie> Movies { get; set; }

        //----------------------------------------------------------------//
    }
}
