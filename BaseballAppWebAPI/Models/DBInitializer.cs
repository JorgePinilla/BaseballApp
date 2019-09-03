using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Json;

public static class DBInitializer {
    public static void Seed(DBContext context){
        var mlbApi = new BaseballApi();

        if(!context.Team.Any()){
            Console.WriteLine("Seeding Teams, Venues, Leagues, Divisions and Sport tables ...");
            JsonValue teams = mlbApi.GetMLBTeams();
            Dictionary<int, Team> teamList = new Dictionary<int, Team>();

            foreach(JsonValue item in teams){
                var team = new Team(){
                    Id = item["id"],
                    Name = item["name"],
                    Venue = new Venue(){
                        Id = item["venue"]["id"],
                        Name = item["venue"]["name"]
                    },
                    TeamCode = item["teamCode"],
                    FileCode = item["fileCode"],
                    Abbreviation = item["abbreviation"],
                    TeamName = item["teamName"],
                    LocationName = item["locationName"],
                    FirstYearOfPlay = item["firstYearOfPlay"],
                    League = new League(){
                        Id = item["league"]["id"],
                        Name = item["league"]["name"],
                        Abbreviation = "",
                        IsSpringLeague = false
                    },
                    Division = new Division(){
                        Id = item["division"]["id"],
                        Name = item["division"]["name"]
                    },
                    Sport = new Sport(){
                        Id = item["sport"]["id"],
                        Name = item["sport"]["name"]
                    },
                    ShortName = item["shortName"],
                    SpringLeague = new League(){
                        Id = item["springLeague"]["id"],
                        Name = item["springLeague"]["name"],
                        Abbreviation = item["springLeague"]["abbreviation"],
                        IsSpringLeague = true
                    },
                    AllStarStatus = item["allStarStatus"],
                    Active = item["active"]
                };
                if(!teamList.ContainsKey(item["id"]))
                    teamList.Add(item["id"], team);
            }

            context.AddRange(teamList.Values);
            context.SaveChanges();
        }

        if(!context.Roster.Any()){
            Console.WriteLine("Seeding Roster and Position tables ...");
            var teams = context.Team.ToList();
            Dictionary<int, Roster> rosterList = new Dictionary<int, Roster>();

            foreach(var t in teams){
                var teamRoster = mlbApi.GetTeamRosterStats(t.Id);

                foreach(JsonValue person in teamRoster){
                    var rosterPerson = new Roster(){
                        PersonId = person["person"]["id"],
                        TeamId = person["parentTeamId"],
                        FullName = person["person"]["fullName"],
                        JerseyNumber = person["jerseyNumber"],
                        BirthDate = person["person"]["birthDate"],
                        BirthCountry = person["person"]["birthCountry"],
                        Height = person["person"]["height"],
                        Weight = person["person"]["weight"],
                        Position = new Position(){
                            Code = person["position"]["code"],
                            Name = person["position"]["name"],
                            Type = person["position"]["type"],
                            Abbreviation = person["position"]["abbreviation"]
                        },
                        Status = person["status"]["description"],
                        Season = "",
                        StatGroup = ""
                    };

                    if(person["person"].ContainsKey("stats")){
                        var rosterStats = person["person"]["stats"][0]["splits"];

                        foreach(JsonValue stat in rosterStats){
                            if(stat.ContainsKey("team") && stat["team"]["id"].ToString() == person["parentTeamId"].ToString()){
                                rosterPerson.Season = stat["season"];
                                rosterPerson.StatGroup = person["person"]["stats"][0]["group"]["displayName"];
                            }
                        }
                    }
                    if(!rosterList.ContainsKey(person["person"]["id"]))
                        rosterList.Add(person["person"]["id"], rosterPerson);
                }
            }

            context.AddRange(rosterList.Values);
            context.SaveChanges();
        }

        if(!context.Person.Any()){
            Console.WriteLine("Seeding Players and stats table ...");
            var players = context.Roster.ToList();
            Dictionary<int, Person> personList = new Dictionary<int, Person>();
            List<Stat> statList = new List<Stat>();

            foreach(var p in players){
                var people = mlbApi.GetPersonStats(p.PersonId)[0];

                var person = new Person(){
                    Id = people["id"],
	                FullName = people["fullName"],
	                FirstName = people["firstName"],
	                LastName = people["lastName"],
	                BirthDate = people["birthDate"],
                    Age = people["currentAge"],
	                BirthCity = people["birthCity"],
	                BirthCountry = people["birthCountry"],
	                Height = people["height"],
	                Weight = people["weight"],
	                Active = people["active"],
	                Position = new Position(){ 
                        Code = people["primaryPosition"]["code"],
                        Name = people["primaryPosition"]["name"],
                        Type = people["primaryPosition"]["type"],
                        Abbreviation = people["primaryPosition"]["abbreviation"]
                    },
	                Gender = people["gender"],
	                IsPlayer = people["isPlayer"],
	                IsVerified = people["isVerified"],
	                BatSide = people["batSide"]["description"],
	                PitchHand = people["pitchHand"]["description"],
                    PrimaryNumber = 0,
                    BirthStateProvince = null,
                    MiddleName = "---",
                    NickName = null,
                    DraftYear = "---",
                    MLBDebutDate = null
                };

                if(people.ContainsKey("primaryNumber"))
                    person.PrimaryNumber = people["primaryNumber"];

                if(people.ContainsKey("birthStateProvince"))
                    person.BirthStateProvince = people["birthStateProvince"];

                if(people.ContainsKey("middleName"))
                    person.MiddleName = people["middleName"];

                if(people.ContainsKey("nickName"))
                    person.NickName = people["nickName"];

                if(people.ContainsKey("draftYear"))
                    person.DraftYear = people["draftYear"].ToString();

                if(people.ContainsKey("mlbDebutDate"))
                    person.MLBDebutDate = people["mlbDebutDate"];

                if(!personList.ContainsKey(people["id"]))
                    personList.Add(people["id"], person);


                if(people.ContainsKey("stats")){
                    foreach(JsonValue stat in people["stats"]){
                        foreach(JsonValue split in stat["splits"]){
                            var playerStat = new Stat(){
                                PersonId = people["id"],
                                TeamId = 0,
                                StatGroup = stat["group"]["displayName"],
                                Season = split["season"],
                                PositionCode = ""
                            };

                            if(split.ContainsKey("team")){
                                playerStat.TeamId = split["team"]["id"];
                                playerStat.Name = playerStat.Season + " - " + split["team"]["name"];
                            }

                            if(playerStat.StatGroup == "fielding")
                                playerStat.PositionCode = split["stat"]["position"]["code"];

                            // "Overall" stats
                            if(playerStat.StatGroup == "hitting" || playerStat.StatGroup == "pitching"){
                                playerStat.GamesPlayed = split["stat"]["gamesPlayed"];
                                playerStat.Runs = split["stat"]["runs"];
                                playerStat.HomeRuns = split["stat"]["homeRuns"];
                                playerStat.StrikeOuts = split["stat"]["strikeOuts"];
                                playerStat.Hits = split["stat"]["hits"];
                                playerStat.AVG = split["stat"]["avg"];
                                playerStat.OBP = split["stat"]["obp"];
                                playerStat.SLG = split["stat"]["slg"];
                                playerStat.OPS = split["stat"]["ops"];
                                playerStat.StolenBasePercentage = split["stat"]["stolenBasePercentage"];
                            }
                            else{ // Only Fielding
                                playerStat.Name += " - " + split["stat"]["position"]["name"] 
                                                 + " (" + split["stat"]["position"]["abbreviation"] + ")";
                                playerStat.GamesPlayed = split["stat"]["games"];
                                playerStat.GamesStarted = split["stat"]["gamesStarted"];
                                playerStat.Assists = split["stat"]["assists"];
                                playerStat.PutOuts = split["stat"]["putOuts"];
                                playerStat.Errors = split["stat"]["errors"];
                                playerStat.Chances = split["stat"]["chances"];
                                playerStat.Fielding = split["stat"]["fielding"];

                                if(playerStat.Fielding == "")
                                    playerStat.Fielding = "---";
                            }
                        
                            // Only hitting stats
                            if(playerStat.StatGroup == "hitting"){
                                playerStat.Doubles = split["stat"]["doubles"];
                                playerStat.Triples = split["stat"]["triples"];
                                playerStat.RBI = split["stat"]["rbi"];
                                playerStat.BABIP = split["stat"]["babip"];   
                            }

                            // Only Pitching stats
                            if(playerStat.StatGroup == "pitching"){
                                playerStat.GamesStarted = split["stat"]["gamesStarted"];
                                playerStat.ERA = split["stat"]["era"];
                                playerStat.Wins = split["stat"]["wins"];
                                playerStat.Losses = split["stat"]["losses"];
                                playerStat.Whip = split["stat"]["whip"];
                                playerStat.StrikePercentage = split["stat"]["strikePercentage"];
                                playerStat.WinPercentage = split["stat"]["winPercentage"];
                                playerStat.GamesFinished = split["stat"]["gamesFinished"];
                                playerStat.StrikeOutWalkRatio = split["stat"]["strikeoutWalkRatio"];   
                            }
                        
                            var seasonYear = Int32.Parse(playerStat.Season);
                            if(playerStat.TeamId != 0 && seasonYear >= DateTime.Now.Year - 2)
                                statList.Add(playerStat);
                        }
                    }
                }
            }
            
            context.AddRange(personList.Values);
            context.AddRange(statList);
            context.SaveChanges();
        }
    }
}