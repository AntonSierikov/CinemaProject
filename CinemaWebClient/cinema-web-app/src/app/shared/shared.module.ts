import { NgModule } from "@angular/core";
import { SliderTemplateComponent } from "./components/slider-template/slider.template";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { JoinElementsPipe } from "./pipes/join.elements.pipe";

@NgModule({
    imports: [
        CommonModule,
        BrowserModule
    ],
    declarations: [
        SliderTemplateComponent,
        JoinElementsPipe
    ],
    exports: [
        SliderTemplateComponent,
        JoinElementsPipe
    ],
    providers:[]
})
export class SharedModule{}