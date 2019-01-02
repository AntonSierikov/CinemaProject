import { Component, Input, OnInit } from "@angular/core";
import { SliderItemModel } from "./models/slider.item";
import * as $ from 'jquery';
import 'slick-carousel';

@Component({
    selector: 'slider-template',
    templateUrl : './slider.template.html',
    styleUrls: ['./slider.template.css']
})
export class SliderTemplateComponent implements OnInit{

    @Input() public sliderItems: SliderItemModel[];
    @Input() public sliderTitle: string;
    @Input() public sliderId: string;

    ngOnInit(){}

    ngAfterViewInit(){
      this.InitSlick();
    }

    InitSlick(): void{
        $(`.${this.sliderId}`).slick({
            dots: false,
            prevArrow: $(`.prev-${this.sliderId}`),
            nextArrow: $(`.next-${this.sliderId}`),
            infinite: false,
            speed: 300,
            slidesToShow: 6,
            slidesToScroll: 6,
            responsive: [
              {
                breakpoint: 1024,
                settings: {
                  slidesToShow: 3,
                  slidesToScroll: 3,
                  infinite: true,
                  dots: false
                }
              },
              {
                breakpoint: 600,
                settings: {
                  slidesToShow: 2,
                  slidesToScroll: 2
                }
              },
              {
                breakpoint: 480,
                settings: {
                  slidesToShow: 1,
                  slidesToScroll: 1
                }
              }
            ]
          });
    }
}