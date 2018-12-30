class MovieInfoModel{
    title: string;
    budget: string;
    overview: string;
    poster_path: string;
    releaseDate: Date;
    runtime: number;
    status: number;
    tagline: string;
    voteAverage: number;
    voteCount: number;

    genres: GenreModel[];
    companies: CompanyModel[];
    countries: CountryModel[];
}