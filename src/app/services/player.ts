
import { Injectable, NgModule } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PlayerModel } from '../player/player.model'
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})

    @NgModule({
        imports: [
            PlayerModel
        ]
})
export class PlayerService {

    constructor(private httpService: HttpClient) {
    }

    public getPlayer(id: number): Observable<PlayerModel> {
        return this.httpService.get<PlayerModel>(`http://localhost:5000/player/${id}`).pipe(
            map(data => new PlayerModel().deserialize(data)),
            //catchError(() => throwError('Player not found'))
        );
    }

    public getAllPlayers(): Observable <PlayerModel[]> {
        return this.httpService.get<PlayerModel[]>('http://localhost:5000/player').pipe(
            map(data => data.map(data => new PlayerModel().deserialize(data)))
        );
    }

    public insertPlayer(player: PlayerModel): Observable<PlayerModel> {
        console.log(player);
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        return this.httpService.post('http://localhost:5000/player/', player, httpOptions).pipe(
            map(data => new PlayerModel().deserialize(data)),
        );
    }

    public updatePlayer(player: PlayerModel): Observable<PlayerModel> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        return this.httpService.put(`http://localhost:5000/player/`, player, httpOptions).pipe(
            map(data => new PlayerModel().deserialize(data)),
        );
    }

    public deletePlayer(id: number): Observable<PlayerModel> {
        return this.httpService.delete(`http://localhost:5000/player/${id}`).pipe(
            map(data => new PlayerModel().deserialize(data)),
        );
    }
}
