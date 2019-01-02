using System;
using System.Collections.Generic;
using System.Linq;
using MovieDomain.Filters;
using CinemaWebCore.Dto;

namespace CinemaWebCore.Mappers
{
    public class FilterMapper
    {
        public static FiltersDto FiltersToDto(MovieEntityFilters filters)
        {
            FiltersDto filtersDto = new FiltersDto()
            {
                GenreFilters = filters.GenreFilters.Select(f => new FilterDto<GenreDto>(new GenreDto(f.FilterValue.Id, f.FilterValue.genre), f.IsAvailable)).ToList(),
                CompanyFilters = filters.CompanyFilters.Select(f => new FilterDto<CompanyDto>(new CompanyDto(f.FilterValue.Id, f.FilterValue.Name), f.IsAvailable)).ToList(),
                CountryFilters = filters.CountryFilters.Select(f => new FilterDto<CountryDto>(new CountryDto(f.FilterValue.Name, f.FilterValue.iso_3166_1), f.IsAvailable)).ToList()
            };

            return filtersDto;
        }
    }
}
