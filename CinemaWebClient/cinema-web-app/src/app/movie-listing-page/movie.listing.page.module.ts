import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FilterComponent } from "./components/filter-component/filter.component";
import { MovieListingPageComponent } from "./components/main-page/movie.listing.page";
import { MovieGridComponent } from "./components/movie-grid/movie.grid.component";
import { SharedModule } from "../shared/shared.module";

@NgModule({
    declarations: [
        FilterComponent,
        MovieListingPageComponent,
        MovieGridComponent
    ],
    imports: [
        BrowserModule,
        SharedModule
    ],
    providers: [
        
    ]
})
export class MovieListingPageModule{}