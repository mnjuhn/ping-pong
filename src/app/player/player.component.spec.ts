import { async, ComponentFixture, TestBed, getTestBed} from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { PlayerService } from '../services/player';
import { PlayerComponent } from './player.component';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from '../app.component';
import { AppModule } from '../app.module';
import { PlayerModel } from './player.model';

describe('PlayerService', () => {
    let injector: TestBed;
    let myProvider: PlayerService;
    let httpMock: HttpTestingController;

    beforeEach(async((myprovider) => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule, RouterTestingModule, AppModule],
            declarations: [AppComponent, PlayerService, PlayerComponent, PlayerModel],
            providers: [PlayerService]
        }).compileComponents();

        let testBed = getTestBed();

        myProvider = testBed.get(PlayerService);

        httpMock = testBed.get(HttpTestingController);
    }));

    myProvider.getAllPlayers.subscribe((players) => {

        expect(players.length).toBe(4);

    });

    myProvider.getPlayer(1).subscribe((player) => {
        expect(player.firstName).toBe("Uncle");
        expect(player.lastName).toBe("Bob");
        expect(player.email).toBe("bob@gmail.com");
        expect(player.age).toBe(51);
        expect(player.skillLevel).toBe("3");
    });

    httpMock.verify();
});


