using System.Collections.Generic;

public interface IDBRepository {
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    IEnumerable<Team> GetTeams();
    Team GetTeam(int id);
    IEnumerable<League> GetLeagues();
    IEnumerable<League> GetRegularLeagues();
    IEnumerable<League> GetSpringLeagues();
    IEnumerable<Division> GetDivisions();
    IEnumerable<Venue> GetVenues();
    Venue GetVenue(int id);
    IEnumerable<Roster> GetRoster(int teamId);
    IEnumerable<Position> GetPositions();
    IEnumerable<Person> GetPeople();
    Person GetPerson(int id);
    IEnumerable<Stat> GetPlayerStatsByGroup(int personId, string statGroup);
    //IEnumerable<Stat[]> GetTeamStats(int teamId);
}