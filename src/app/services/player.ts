
import { Injectable, NgModule } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PlayerComponent } from '../player/player.component'
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})

    @NgModule({
        imports: [
            PlayerComponent
        ]
})
export class PlayerService {

    constructor(private httpService: HttpClient) {
    }

    public getPlayer(id: number): Observable<PlayerComponent> {
        return this.httpService.get<PlayerComponent>(`http://localhost:5000/player/${id}`).pipe(
            map(data => new PlayerComponent().deserialize(data)),
            //catchError(() => throwError('Player not found'))
        );
    }

    public getAllPlayers(): Observable <PlayerComponent[]> {
        return this.httpService.get<PlayerComponent[]>(`http://localhost:5000/player`).pipe(
            map(data => data.map(data => new PlayerComponent().deserialize(data)))
        );
    }
}
