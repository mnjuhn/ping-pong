import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { PlayerComponent } from './player/player.component';
import { PlayerEditor } from './player/player.editor';
import { PlayerInsert } from './player/player.insert';
import { PlayerDelete } from './player/player.delete';
import { RouterModule, Routes } from '@angular/router'
import { HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, FormControl, FormGroupDirective } from '@angular/forms';

const appRoutes: Routes = [
    { path: 'player', component: PlayerComponent },
    { path: 'player-add', component: PlayerInsert },
    { path: 'player/:Id', component: PlayerEditor },
    { path: 'player/delete/:Id', component: PlayerDelete },

]

@NgModule({
  declarations: [
    AppComponent,
        PlayerComponent,
        PlayerEditor,
        PlayerInsert,
        PlayerDelete
        ],
  imports: [
      BrowserModule,
      RouterModule.forRoot(appRoutes),
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
