import { ActivatedRoute } from "@angular/router";
import { Component } from "@angular/core";

@Component({
    selector: 'movie-listing-page',
    templateUrl: './movie.listing.page.html',
    styleUrls: ['./movie.listing.page.css']
})
export class MovieListingPageComponent{

    constructor(activeRoute: ActivatedRoute){
        activeRoute.queryParams.subscribe();
    }
}