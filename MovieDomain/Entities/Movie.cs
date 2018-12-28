using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using MovieDomain.Abstract;
using MovieDomain.AuthEntities;

namespace MovieDomain.Entities
{
    public partial class Movie : DbObject<int>
    {
        public Movie()
        {
            Casts = new List<Cast>();
            Crews = new List<Crew>();
            Genres = new List<Genre>();
            Liked = new List<User>();
            WillWatch = new List<User>();
            Appreciated = new List<User>();
            ProductionCompanies = new List<ProductionCompany>();
            ProductionCountries = new List<ProductionCountry>();
            Comments = new List<Comment>();
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

        public List<Cast> Casts { get; set; }

        public List<Crew> Crews { get; set; }

        public List<Genre> Genres { get; set; }

        public List<ProductionCountry> ProductionCountries { get; set; }

        public List<ProductionCompany> ProductionCompanies { get; set; }

        public List<User> Liked { get; set; } 

        public List<User> WillWatch { get; set; }

        public List<User> Appreciated { get; set; }

        public List<Comment> Comments { get; set; }


        //----------------------------------------------------------------//


    }
}
