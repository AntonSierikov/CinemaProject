using System;
using System.Collections.Generic;
using MovieDomain.AuthEntities;
using MovieDomain.Abstract;
using System.Linq.Expressions;

namespace MovieDomain.Entities
{
    public partial class People : DbObject<int>
    {
        public People()
        {
            Casts = new List<Cast>();
            Crews = new List<Crew>();
        }

        public string Imdb_id { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; } 
        
        public int Gender { get; set; }

        public string Homepage { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? Deathday { get; set; }

        public string PlaceOfBirth { get; set; }

        public double Popularity { get; set; }

        public string ProfilePath { get; set; }

        public IList<Cast> Casts { get; set; }

        public IList<Crew> Crews { get; set; }

        public IList<User> UsersWhoLiked { get; set; }

        //----------------------------------------------------------------//


    }
}
