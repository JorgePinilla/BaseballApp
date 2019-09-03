import { Venue } from './venue';
import { League } from './league';
import { Division } from './division';

export class Team {
    id: number;
    venue: Venue;
    locationName: string;
    name: string;
    firstYearOfPlay: number;
    league: League;
    division: Division;
    springLeagueId: number;
}
