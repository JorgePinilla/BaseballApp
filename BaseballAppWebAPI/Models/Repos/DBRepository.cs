using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class DBRepository : IDBRepository {
    private readonly DBContext _context;
    public DBRepository(DBContext context){
        _context = context;
    }
    public void Add<T>(T entity) where T : class{
        _context.Add(entity);
    }
    public void Update<T>(T entity) where T : class{
        _context.Update(entity);
    }
    public void Delete<T>(T entity) where T : class{
        _context.Remove(entity);
    }
    public IEnumerable<Team> GetTeams(){
        return _context.Team.Include(d => d.Venue)
                            .Include(d => d.League)
                            .Include(d => d.Division)
                            .OrderBy(d => d.Name);
    }
    public Team GetTeam(int id){
        return _context.Team.Include(d => d.Venue)
                            .Include(d => d.League)
                            .Include(d => d.Division)
                            .Where(d => d.Id == id).FirstOrDefault();
    }
    public IEnumerable<League> GetLeagues(){
        return _context.League.ToList();
    }
    public IEnumerable<League> GetRegularLeagues(){
        return _context.League.Where(l => !l.IsSpringLeague);
    }
    public IEnumerable<League> GetSpringLeagues(){
        return _context.League.Where(l => l.IsSpringLeague);
    }
    public IEnumerable<Division> GetDivisions(){
        return _context.Division.ToList();
    }
    public IEnumerable<Venue> GetVenues(){
        return _context.Venue.OrderBy(v => v.Name);
    }
    public Venue GetVenue(int id){
        return _context.Venue.Find(id);
    }
    public IEnumerable<Roster> GetRoster(int teamId){
        return _context.Roster.Include(r => r.Position)
                    .Where(r => r.TeamId == teamId);
    }
    public IEnumerable<Position> GetPositions(){
        return _context.Position.ToList();
    }
    public IEnumerable<Person> GetPeople(){
        return _context.Person.Include(p => p.Position);
    }
    public Person GetPerson(int id){
        return _context.Person.Include(d => d.Position)
                .Where(d => d.Id == id).FirstOrDefault();
    }
    public IEnumerable<Stat> GetPlayerStatsByGroup(int personId, string statGroup){
        return _context.Stat.Where(d => d.PersonId == personId && d.StatGroup == statGroup).OrderByDescending(d => d.Name);
    }
}