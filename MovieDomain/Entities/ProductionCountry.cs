using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using MovieDomain.Abstract;

namespace MovieDomain.Entities
{
    public partial class ProductionCountry : DbObject<int>
    {
        public ProductionCountry()
        {
            Movies = new List<MovieCountry>();
        }

        //----------------------------------------------------------------//

        public string iso_3166_1 { get; set; }

        public string Name { get; set; }

        public IList<MovieCountry> Movies { get; set; }

        //----------------------------------------------------------------//


    }
}
