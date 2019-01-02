export class SliderItemModel{

    ImageUrl: string;
    FirstTitle: string;
    SecondTitle: string;

    constructor(url: string, firstTitle: string, secondTitle: string){
        this.ImageUrl = url;
        this.FirstTitle = firstTitle;
        this.SecondTitle = secondTitle;
    }
}