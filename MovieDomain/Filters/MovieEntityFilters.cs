using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Abstract;
using MovieDomain.Entities;

namespace MovieDomain.Filters
{
    public class MovieEntityFilters
    {
        public List<EntityFilter<Genre>> GenreFilters { get; set; }

        public List<EntityFilter<ProductionCompany>> CompanyFilters { get; set; }

        public List<EntityFilter<ProductionCountry>> CountryFilters { get; set; }
    }
}
