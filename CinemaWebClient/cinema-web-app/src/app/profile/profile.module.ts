import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ProfileComponent } from './profile.component';
import { ProfileInfoComponent } from './profile-info/profile.info';
import { ProfileRoutingModule } from './profile.routing.module';

@NgModule({
    imports : [
        ProfileRoutingModule
    ],
    declarations:[
        ProfileComponent,
        ProfileInfoComponent
    ],
    providers: [], 

})
export class ProfileModule{}