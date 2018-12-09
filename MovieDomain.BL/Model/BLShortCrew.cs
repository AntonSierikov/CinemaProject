using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.BL.Model
{
    public class BLShortCrew
    {
        public readonly string PeopleName;
        public readonly int Popularity;
        public readonly int MovieId;

        //----------------------------------------------------------------//
        //Sub entity

        public BLJob Job;

        public BLMovie Movie;

        //----------------------------------------------------------------//

        public BLShortCrew(string _name, int _popularity, int _movieId)
        {
            PeopleName = _name;
            Popularity = _popularity;
            MovieId = _movieId;
        }

        //----------------------------------------------------------------//

    }
}
