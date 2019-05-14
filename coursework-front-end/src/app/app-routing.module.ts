import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';

import { GamesComponent } from './components/games/games.component';
import { GameComponent } from './components/game/game.component';
import { EditGameComponent } from './components/edit-game/edit-game.component';

import { PlayersComponent } from './components/players/players.component';
import { PlayerComponent } from './components/player/player.component';
import { EditPlayerComponent } from './components/edit-player/edit-player.component';

import { TeamsComponent } from './components/teams/teams.component';
import { TeamComponent } from './components/team/team.component';
import { EditTeamComponent } from './components/edit-team/edit-team.component';

import { MatchesComponent } from './components/matches/matches.component';
import { MatchComponent } from './components/match/match.component';
import { EditMatchComponent } from './components/edit-match/edit-match.component';

const routes: Routes = [
  {
    path: "signin",
    component: SignInComponent
  },
  {
    path: "signup",
    component: SignUpComponent
  },
  
  {
    path: "games",
    component: GamesComponent
  },
  {
    path: "game/create",
    component: EditGameComponent
  },
  {
    path: "game/edit/:id",
    component: EditGameComponent
  },
  {
    path: "game/:id",
    component: GameComponent
  },

  {
    path: "players",
    component: PlayersComponent
  },
  {
    path: "player/create",
    component: EditPlayerComponent
  },
  {
    path: "player/edit/:id",
    component: EditPlayerComponent
  },
  {
    path: "player/:id",
    component: PlayerComponent
  },

  {
    path: "teams",
    component: TeamsComponent
  },
  {
    path: "team/create",
    component: EditTeamComponent
  },
  {
    path: "team/edit/:id",
    component: EditTeamComponent
  },
  {
    path: "team/:id",
    component: TeamComponent
  },

  {
    path: "matches",
    component: MatchesComponent
  },
  {
    path: "match/create",
    component: EditMatchComponent
  },
  {
    path: "match/edit/:id",
    component: EditMatchComponent
  },
  {
    path: "match/:id",
    component: MatchComponent
  },
  // {
  //   path: "**",
  //   redirectTo: "signin"
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
