﻿using System;
using MovieDomain.Entities;
using MovieDomain.Identifiers;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Commands
{
    internal class MovieCountryCommand : BaseCommand<MovieCountry, MovieCountryId>, IMovieCountryCommand
    {
        public MovieCountryCommand(ISession session) : base(session)
        {}

        protected override string GenerateInsertQuery(MovieCountry item)
        {
            string insert = $@"INSERT INTO {TableName}(MovieId, CountryId)
                               OUTPUT INSERTED.MovieId, INSERTED.CountryId
                               VALUES(@{nameof(item.Id.MovieId)}, @{nameof(item.Id.CountryId)})";
            return insert;
        }

        protected override string GenerateUpdateQuery(MovieCountry item)
        {
            throw new NotImplementedException();
        }
    }
}
