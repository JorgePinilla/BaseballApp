using System.ComponentModel.DataAnnotations;

public class Division {
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