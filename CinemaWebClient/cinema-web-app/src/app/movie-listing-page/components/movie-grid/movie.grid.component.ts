import { Component, Input } from "@angular/core";
import { ShortMovieInfoModel } from "../../models/short.movie.info.model";


@Component({
    selector: 'movie-grid',
    templateUrl: './movie.grid.component.html',
    styleUrls: ['./movie.grid.component.css']
})
export class MovieGridComponent{

    @Input() shortMovieInfoModels: ShortMovieInfoModel[];
}