namespace CinemaWebCore.Dto
{
    public class GenreDto
    {
        public readonly int GenreId;
        public readonly string Genre;

        //----------------------------------------------------------------//

        public GenreDto(int _id, string _genre)
        {
            GenreId = _id;
            Genre = _genre;
        }

        //----------------------------------------------------------------//

    }
}
