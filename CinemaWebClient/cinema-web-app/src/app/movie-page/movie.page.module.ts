import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { MoviePageService } from "./services/movie.page.service";
import { MoviePageComponent } from "./components/movie.page.component";

@NgModule({
    declarations: [
        MoviePageComponent
    ],
    imports: [
        BrowserModule,
    ],
    providers: [
        MoviePageService
    ]
})
export class MoviePageModule{}