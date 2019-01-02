import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { MoviePageComponent } from './movie-page/components/movie.page.component';
import { MovieListingPageComponent } from './movie-listing-page/components/main-page/movie.listing.page';

const routes: Routes = [
  { path: 'Profile',  component : ProfileComponent },
  { path: 'Movie/:movieId',  component : MoviePageComponent },
  { path: 'MovieList', component: MovieListingPageComponent } //loadChildren: './profile/profile.module#ProfileModule', }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
