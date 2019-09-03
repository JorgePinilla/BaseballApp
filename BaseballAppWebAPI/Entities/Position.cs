using System.ComponentModel.DataAnnotations;

public class Position {
    [Key]
    public string Code {
        get;
        set;
    }
    public string Name {
        get;
        set;
    }
    public string Type {
        get;
        set;
    }
    public string Abbreviation {
        get;
        set;
    }
}