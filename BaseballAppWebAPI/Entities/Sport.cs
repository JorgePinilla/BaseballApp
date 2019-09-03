using System.ComponentModel.DataAnnotations;

public class Sport {
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