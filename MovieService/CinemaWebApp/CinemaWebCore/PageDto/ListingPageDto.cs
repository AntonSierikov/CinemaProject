using System;
using System.Collections.Generic;
using System.Text;
using CinemaWebCore.Dto;

namespace CinemaWebCore.PageDto
{
    public class ListingPageDto
    {
        public List<ShortMovieInfoDto> MovieGrid { get; private set; }

        public FiltersDto Filters { get; private set; }

        public ListingPageDto(List<ShortMovieInfoDto> _grid, FiltersDto _filters)
        {
            MovieGrid = _grid;
            Filters = _filters;
        }
    }
}
