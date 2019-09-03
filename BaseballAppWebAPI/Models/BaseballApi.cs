using System.IO;
using System.Json;
using System.Net;
using System.Text;

public class BaseballApi {
    protected string api = "https://statsapi.mlb.com/api/v1/";
    protected string mlbTeams = "teams?sportId=1";
    protected string playerStats = "?hydrate=stats(group=[hitting,pitching,fielding],type=[yearByYear])";
    protected string rosterStats = "Active?hydrate=person(stats(type=season))";
    
    public BaseballApi(){

    }
    public JsonValue GetMLBTeams(){
        var json = GetApiData(api + mlbTeams);
        return json["teams"];
    }

    public JsonValue GetTeamRoster(int teamId){
        var json = GetApiData(api + "teams/" + teamId + "/roster");
        return json["roster"];
    }

    public JsonValue GetTeamRosterStats(int teamId){
        var json = GetApiData(api + "teams/" + teamId + "/roster/" + rosterStats);
        return json["roster"];
    }

    public JsonValue GetPerson(int personId){
        var json = GetApiData(api + "people/" + personId);
        return json["people"];
    }

    public JsonValue GetPersonStats(int personId){
        var json = GetApiData(api + "people/" + personId + playerStats);
        return json["people"];
    }

    public JsonValue GetApiData(string url){
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = WebRequestMethods.Http.Get;
        request.Accept = "application/json";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        return JsonValue.Parse(reader.ReadToEnd());
    }
}