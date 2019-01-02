import { Component, OnInit } from "@angular/core";
import { MoviePageService } from "../services/movie.page.service";
import { ActivatedRoute } from "@angular/router";
import { StringConstants } from "../../shared/constants/string.constants";
import { SliderTemplateComponent } from "../../shared/components/slider-template/slider.template";
import { CreditsModel } from "../../shared/models/movie-general-models/credits.model";
import { MoviePageMapper } from "../services/movie.page.mapper";
import { SliderItemModel } from "../../shared/components/slider-template/models/slider.item";
import { CinemaEntitiesComparers } from "../../shared/comparers/cinema.entities.comparers";

@Component({
    selector: 'movie-page',
    templateUrl: './movie.page.component.html',
    styleUrls: ['./movie.page.css']
})
export class MoviePageComponent implements OnInit{

    movieId: number;

    movieInfo: MovieInfoModel;
    countryCodes: string[];
    creditsInfo: CreditsModel;
    castSliderItems: SliderItemModel[];
    crewSliderItems: SliderItemModel[];

    constructor(private moviePageService: MoviePageService, private activeRoute: ActivatedRoute){
    }

    ngOnInit(){
        this.activeRoute.params.subscribe(params => 
        {  
            this.movieId = params['movieId'];
            this.moviePageService.getMovieInfo(this.movieId).subscribe(data => this.onLoadedMovieInfo(data));
            this.moviePageService.getMovieCredits(this.movieId).subscribe(data => this.onLoadedCredits(data));
        }); 
    }

    companySelector = (company: CompanyModel) => company.companyName;

    genreSelector = (genre: GenreModel) => genre.genre;

    onLoadedMovieInfo(data: MovieInfoModel): void{
        this.movieInfo = data;
        this.countryCodes = this.movieInfo.countries.filter((v, i, array) => v.iso_3166_1)
                                                    .map((v, i, array) => v.iso_3166_1);
    }

    onLoadedCredits(data: CreditsModel): void{
        this.creditsInfo = data;
        this.creditsInfo.casts = this.creditsInfo.casts.sort(CinemaEntitiesComparers.CastComparer);
        this.castSliderItems = this.creditsInfo.casts.map(MoviePageMapper.MapCastToSliderItems);
        this.crewSliderItems = this.creditsInfo.crews.map(MoviePageMapper.MapCrewToSliderItems);
    }

    likeMovie(event: Event): void{

    } 

    viewMovie(event: Event): void{

    }
}