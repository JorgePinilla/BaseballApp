using System.ComponentModel.DataAnnotations;

public class Roster {
    [Key]
    public int PersonId {
        get;
        set;
    }
    public int TeamId {
        get;
        set;
    }
    public string Season {
        get;
        set;
    }
    public string FullName {
        get;
        set;
    }
    public int JerseyNumber {
        get;
        set;
    }
    public string BirthDate {
        get;
        set;
    }
    public string BirthCountry {
        get;
        set;
    }
    public string Height {
        get;
        set;
    }
    public int Weight {
        get;
        set;
    }
    public Position Position {
        get;
        set;
    }
    public string StatGroup {
        get;
        set;
    }
    public string Status {
        get;
        set;
    }
}