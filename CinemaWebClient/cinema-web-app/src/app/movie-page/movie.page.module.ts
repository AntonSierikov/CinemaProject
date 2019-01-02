import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { MoviePageComponent } from "./components/movie.page.component";
import { JoinElementsPipe } from "../shared/pipes/join.elements.pipe";
import { SharedModule } from "../shared/shared.module";
import { MoviePageService } from "./services/movie.page.service";

@NgModule({
    declarations: [
        MoviePageComponent
    ],
    imports: [
        BrowserModule,
        SharedModule
    ],
    providers: [
        MoviePageService
    ]
})
export class MoviePageModule{}