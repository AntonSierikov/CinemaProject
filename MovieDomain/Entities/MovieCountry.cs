using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MovieDomain.Abstract;
using MovieDomain.Identifiers;

namespace MovieDomain.Entities
{
    public class MovieCountry : DbObject<MovieCountryId>
    {
        public Movie Movie { get; set; }

        public ProductionCountry Country { get; set; }

        //----------------------------------------------------------------//

        public MovieCountry() {}

        //----------------------------------------------------------------//
            
        public MovieCountry(int movieId, int countryId)
        {
            Id = new MovieCountryId(movieId, countryId);
        }
            
        //----------------------------------------------------------------//

        public MovieCountry(Movie movie, ProductionCountry country)
            : this(movie.Id, country.Id)
        {
            Movie = movie;
            Country = country;
        }

        //----------------------------------------------------------------//

    }
}
