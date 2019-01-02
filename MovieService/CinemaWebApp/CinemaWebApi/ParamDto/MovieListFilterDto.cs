using Microsoft.AspNetCore.Mvc;

namespace CinemaWebApi.ParamDto
{
    public class MovieListFilterDto
    {
        public string Genre { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public int PageNumber { get; set; }
    }
}
