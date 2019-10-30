import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { PlayerComponent } from './player/player.component';
import { RouterModule, Routes } from '@angular/router'
import { HttpClientModule } from '@angular/common/http';

const appRoutes: Routes = [
    { path: 'player', component: PlayerComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    PlayerComponent
  ],
  imports: [
      BrowserModule,
      RouterModule.forRoot(appRoutes),
      HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
