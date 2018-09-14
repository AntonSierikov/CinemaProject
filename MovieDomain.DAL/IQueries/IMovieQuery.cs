using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Entities;

namespace MovieDomain.DAL.IQueries
{
    public interface IMovieQuery : IQuery<Movie, int>
    {

        //----------------------------------------------------------------//

        Movie GetMovie(string title);

        //----------------------------------------------------------------//

    }
}
