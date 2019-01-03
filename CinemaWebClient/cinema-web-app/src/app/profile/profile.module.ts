import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ProfileComponent } from './profile.component';
import { ProfileInfoComponent } from './profile-info/profile.info';
import { ProfileRoutingModule } from './profile.routing.module';
import { ProfileMiddleColumnComponent} from './middle-column/middle-column'

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