using System.ComponentModel.DataAnnotations;

public class Team {
    [Key]
    public int Id {
        get;
        set;
    }
    public string Name {
        get;
        set;
    }
    public Venue Venue {
        get;
        set;
    }
    public string TeamCode {
        get;
        set;
    }
	public string FileCode {
        get;
        set;
    }
	public string Abbreviation {
        get;
        set;
    }
	public string TeamName {
        get;
        set;
    }
	public string LocationName {
        get;
        set;
    }
	public int FirstYearOfPlay {
        get;
        set;
    }
	public League League {
        get;
        set;
    }
	public Division Division {
        get;
        set;
    }
	public Sport Sport {
        get;
        set;
    }
	public string ShortName {
        get;
        set;
    }
	public League SpringLeague {
        get;
        set;
    }
	public string AllStarStatus {
        get;
        set;
    }
	public bool Active {
        get;
        set;
    }
}