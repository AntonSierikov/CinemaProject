import { HttpClient, HttpParams } from '@angular/common/http'
import { Observable } from 'rxjs' 
import { Injectable } from '@angular/core';
import { CreditsModel } from '../../shared/models/movie-general-models/credits.model';

@Injectable()
export class MoviePageService{
    constructor(private httpClient: HttpClient){}

    getMovieInfo(movieId: number) : Observable<MovieInfoModel>{
        return this.httpClient.get<MovieInfoModel>(`/api/Movie/${movieId}`);
    }

    getMovieCredits(movieId: number) : Observable<CreditsModel>{
        return this.httpClient.get<CreditsModel>(`/api/Credit/GetAllByMovieId/${movieId}`);
    }
}