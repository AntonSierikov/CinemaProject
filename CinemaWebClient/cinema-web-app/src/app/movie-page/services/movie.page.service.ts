import { HttpClient, HttpParams } from '@angular/common/http'
import { Observable } from 'rxjs' 
import { Injectable } from '@angular/core';

@Injectable()
export class MoviePageService{
    constructor(private httpClient: HttpClient){}

    getMovieInfo(movieId: number) : Observable<MovieInfoModel>{
        return this.httpClient.get<MovieInfoModel>(`/GetMovieInfo/${movieId}`);
    }

    getMovieCredits(movieId: number) : Observable<CreditsModel>{
        return this.httpClient.get<CreditsModel>(`/GetCredits/${movieId}`);
    }
}