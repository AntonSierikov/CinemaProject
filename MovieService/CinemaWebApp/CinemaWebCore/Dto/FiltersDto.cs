using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class FiltersDto
    {
        public List<FilterDto<GenreDto>> GenreFilters { get; set; }

        public List<FilterDto<CompanyDto>> CompanyFilters { get; set;}

        public List<FilterDto<CountryDto>> CountryFilters { get; set; }
    }
}
