import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent,  } from './app.component';
import { HeaderComponent } from './header/app.header.component';
import { MoviePageModule } from './movie-page/movie.page.module';
import { ProfileModule } from './profile/profile.module';
import { HttpClientModule } from '@angular/common/http';
import { MovieListingPageModule } from './movie-listing-page/movie.listing.page.module';


@NgModule({
  declarations: [
    AppComponent, 
    HeaderComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    MoviePageModule,
    ProfileModule,
    MovieListingPageModule
  ],
  providers: [],
  bootstrap: [AppComponent, HeaderComponent]
})
export class AppModule {}
