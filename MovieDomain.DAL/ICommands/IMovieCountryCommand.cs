﻿using MovieDomain.Entities;
using MovieDomain.Identifiers;

namespace MovieDomain.DAL.ICommands
{
    public interface IMovieCountryCommand: ICommand<MovieCountry, MovieCountryId>
    {
    }
}
