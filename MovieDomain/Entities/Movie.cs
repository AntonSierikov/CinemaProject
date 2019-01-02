using System;
using System.Collections.Generic;
using MovieDomain.Abstract;
using MovieDomain.AuthEntities;
using MovieDomain.EqualityComparers;
using MovieDomain.ComparerFactories;

namespace MovieDomain.Entities
{
    public class Movie : DbObject<int>
    {
        public Movie()
        {
            Casts = new HashSet<Cast>(EqualityComparerFactory.BaseDbIntPKComparer);
            Crews = new HashSet<Crew>(EqualityComparerFactory.BaseDbIntPKComparer);
            Genres = new HashSet<Genre>(EqualityComparerFactory.BaseDbIntPKComparer);
            Liked = new HashSet<User>(EqualityComparerFactory.BaseDbIntPKComparer);
            WillWatch = new HashSet<User>(EqualityComparerFactory.BaseDbIntPKComparer);
            Appreciated = new HashSet<User>(EqualityComparerFactory.BaseDbIntPKComparer);
            ProductionCompanies = new HashSet<ProductionCompany>(EqualityComparerFactory.BaseDbIntPKComparer);
            ProductionCountries = new HashSet<ProductionCountry>(EqualityComparerFactory.BaseDbIntPKComparer);
            Comments = new HashSet<Comment>(EqualityComparerFactory.BaseDbIntPKComparer);
        }

        public int Tmdb_ID { get; set; }

        public bool Adult { get; set; }

        public string Backdrop_path { get; set; }

        public int Budget { get; set; }

        public string BelongsToCollection { get; set; }

        public string Imdb_id { get; set; }

        public string Original_language { get; set; }

        public string Original_title { get; set; }

        public string Overview { get; set; }

        public double Popularity { get; set; }

        public string Poster_path { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Revenue { get; set; }

        public int? Runtime { get; set; }

        public string Status { get; set; }

        public string Tagline { get; set; }

        public string Title { get; set; }

        public bool Video { get; set; }

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }

        public HashSet<Cast> Casts { get; set; }

        public HashSet<Crew> Crews { get; set; }

        public HashSet<Genre> Genres { get; set; }

        public HashSet<ProductionCountry> ProductionCountries { get; set; }

        public HashSet<ProductionCompany> ProductionCompanies { get; set; }

        public HashSet<User> Liked { get; set; } 

        public HashSet<User> WillWatch { get; set; }

        public HashSet<User> Appreciated { get; set; }

        public HashSet<Comment> Comments { get; set; }


        //----------------------------------------------------------------//


    }
}
