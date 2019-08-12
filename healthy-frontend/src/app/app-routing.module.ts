import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { EventsLogComponent } from './events-log/events-log.component';


const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'log', component: EventsLogComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
