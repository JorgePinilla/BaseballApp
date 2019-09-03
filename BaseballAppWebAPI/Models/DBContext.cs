using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class DBContext : IdentityDbContext {
    private IConfigurationRoot _config;
    public DBContext(DbContextOptions<DBContext> options, IConfigurationRoot config) : base(options){
        _config = config;
    }

    public DbSet<Team> Team {
        get;
        set;
    }
    public DbSet<League> League {
        get;
        set;
    }
    public DbSet<Division> Division {
        get;
        set;
    }
    public DbSet<Venue> Venue {
        get;
        set;
    }
    public DbSet<Sport> Sport {
        get;
        set;
    }
    public DbSet<Roster> Roster {
        get;
        set;
    }
    public DbSet<Position> Position {
        get;
        set;
    }
    public DbSet<Person> Person {
        get;
        set;
    }
    public DbSet<Stat> Stat {
        get;
        set;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_config["ConnectionStrings:MyConnection"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Roster>()
            .Property(e => e.BirthDate)
            .HasConversion(
                d => Convert.ToDateTime(d).Date,
                d => String.Format("{0:MM/dd/yyyy}", d)
            );

        modelBuilder.Entity<Person>()
            .Property(e => e.BirthDate)
            .HasConversion(
                d => Convert.ToDateTime(d).Date,
                d => String.Format("{0:MM/dd/yyyy}", d)
            );

        modelBuilder.Entity<Person>()
            .Property(e => e.MLBDebutDate)
            .HasConversion(
                d => Convert.ToDateTime(d).Date,
                d => String.Format("{0:MM/dd/yyyy}", d)
            );
        
        modelBuilder.Entity<Stat>()
            .HasKey(d => new {
                d.PersonId,
                d.TeamId,
                d.StatGroup,
                d.Season,
                d.PositionCode
            });
    }
}