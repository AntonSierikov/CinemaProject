import { CastModel } from "../models/movie-general-models/cast.model";


export class CinemaEntitiesComparers{

    public static CastComparer(first: CastModel, second: CastModel) : number{
        if(first.order > second.order){
            return 1;
        }
        else if(!second.order){
            return 0;
        }
        else{
            return -1;
        }
    }

}