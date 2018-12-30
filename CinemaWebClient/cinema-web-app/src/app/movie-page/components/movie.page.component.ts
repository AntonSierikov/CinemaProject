import { Component, OnInit } from "@angular/core";
import { MoviePageService } from "../services/movie.page.service";
import { ActivatedRoute } from "@angular/router";
import { StringConstants } from "../../shared/constants/string.constants";

@Component({
    selector: 'movie-page',
    template: 'movie.page.component.html',
    styles: ['movie.page.css']
})
export class MoviePageComponent implements OnInit{

    movieId: number;

    movieInfo: MovieInfoModel;
    creditsInfo: CreditsModel;

    StringConstants: StringConstants;

    constructor(private moviePageService: MoviePageService, private activeRoute: ActivatedRoute){
    }

    ngOnInit(){
        this.activeRoute.params.subscribe(params => 
        {  
            this.movieId = params['movieId'];
            this.moviePageService.getMovieInfo(this.movieId).subscribe(data => this.movieInfo = data);
            this.moviePageService.getMovieCredits(this.movieId).subscribe(data => this.creditsInfo = data);
        }); 
    }
}