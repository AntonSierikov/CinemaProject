﻿using MovieDomain.Entities;

namespace MovieDomain.DAL.ICommands
{
    public interface ICountryCommand : ICommand<ProductionCountry, int>
    {
    }
}
