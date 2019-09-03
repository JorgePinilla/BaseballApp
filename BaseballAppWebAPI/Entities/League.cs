using System.ComponentModel.DataAnnotations;

public class League {
    [Key]
    public int Id {
        get;
        set;
    }
    public string Name {
        get;
        set;
    }
    public string Abbreviation {
        get;
        set;
    }
    public bool IsSpringLeague {
        get;
        set;
    }
}