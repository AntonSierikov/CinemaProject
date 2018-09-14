using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Entities;

namespace MovieDomain.DAL.IQueries
{
    public interface IGenreQuery : IQuery<Genre, int>
    {
        Genre GetGenre(string genre);
    }
}
