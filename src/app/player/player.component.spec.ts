import { async, TestBed, getTestBed} from '@angular/core/testing';
import { PlayerService } from '../services/player';
import { PlayerComponent } from './player.component';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientModule } from '@angular/common/http';

describe('PlayerService', () => {
    let injector: TestBed;
    let myProvider: PlayerService;

    beforeEach(async(() => {
        TestBed.configureTestingModule({

            imports: [HttpClientModule, RouterTestingModule],
            declarations: [PlayerComponent],
            providers: [PlayerService, PlayerModel]
        }).compileComponents();

        let testBed = getTestBed();

        myProvider = testBed.get(PlayerService);

    }));

    it('Originally there should only be 4 Users', (done) => {
        myProvider.getAllPlayers().subscribe((players) => {
            expect(players.length).toEqual(4);
            done()
        });
    });

    it('The first user should be Uncle Bob', (done)=> {
        myProvider.getPlayer(1).subscribe((player) => {
            expect(player.firstName).toBe("Uncle");
            expect(player.lastName).toBe("Bob");
            expect(player.email).toBe("bob@gmail.com");
            expect(player.age).toBe(51);
            done();
        });
    });

});


