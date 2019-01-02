using System;
using System.Collections.Generic;
using MovieDomain.AuthEntities;
using MovieDomain.Abstract;
using MovieDomain.ComparerFactories;

namespace MovieDomain.Entities
{
    public class People : DbObject<int>
    {
        public People()
        {
            Casts = new HashSet<Cast>(EqualityComparerFactory.BaseDbIntPKComparer);
            Crews = new HashSet<Crew>(EqualityComparerFactory.BaseDbIntPKComparer);
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

        public HashSet<Cast> Casts { get; set; }

        public HashSet<Crew> Crews { get; set; }

        public IList<User> UsersWhoLiked { get; set; }

        //----------------------------------------------------------------//


    }
}
