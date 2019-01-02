import { CastModel } from "../../shared/models/movie-general-models/cast.model";
import { CrewModel } from "../../shared/models/movie-general-models/crew.model";
import { SliderItemModel } from "../../shared/components/slider-template/models/slider.item";

export class MoviePageMapper{

    static MapCastToSliderItems(cast: CastModel, index: number, casts: CastModel[]): SliderItemModel{
        return new SliderItemModel(cast.imagePath, cast.peopleName, cast.character);
    }

    static MapCrewToSliderItems(crew: CrewModel, index: number, crews: CrewModel[]): SliderItemModel{
        return new SliderItemModel(crew.imagePath, crew.peopleName, crew.job);
    }
}