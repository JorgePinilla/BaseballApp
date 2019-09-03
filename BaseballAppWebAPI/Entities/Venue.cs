using System.ComponentModel.DataAnnotations;

public class Venue {
    [Key]
    public int Id {
        get;
        set;
    }
    public string Name {
        get;
        set;
    }
}