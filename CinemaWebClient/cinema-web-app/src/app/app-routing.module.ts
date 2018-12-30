import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { MoviePageComponent } from './movie-page/components/movie.page.component';


const routes: Routes = [
  { path: 'profile',  component : ProfileComponent },
  { path: 'movie/:movieId',    component : MoviePageComponent } //loadChildren: './profile/profile.module#ProfileModule', }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
