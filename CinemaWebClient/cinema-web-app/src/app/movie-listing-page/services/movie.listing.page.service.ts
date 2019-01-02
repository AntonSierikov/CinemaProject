import { Injectable } from "@angular/core";
import { SelectedFiltersModel } from "../models/selected.filters.model";
import { Observable } from "rxjs";
import { ShortMovieInfoModel } from "../models/short.movie.info.model";
import { HttpClient, HttpParams } from "@angular/common/http";

@Injectable()
export class MovieListingPageService{

    constructor(private httpClient: HttpClient){}

    LoadList(selectedFilter: SelectedFiltersModel) : Observable<ShortMovieInfoModel> {
        let params = new HttpParams();
        Object.keys(selectedFilter).forEach(function (key) {
            params = params.append(key, selectedFilter[key]);
       });
        return this.httpClient.get<ShortMovieInfoModel>('/api/MovieList', { params : params });
    }

}