using System.ComponentModel.DataAnnotations;

public class Person {
    [Key]
    public int Id {
        get;
        set;
    }
	public string FullName {
        get;
        set;
    }
	public string FirstName {
        get;
        set;
    }
    public string MiddleName {
        get;
        set;
    }
	public string LastName {
        get;
        set;
    }
	public int PrimaryNumber {
        get;
        set;
    }
	public string BirthDate {
        get;
        set;
    }
	public int Age {
        get;
        set;
    }
	public string BirthCity {
        get;
        set;
    }
    public string BirthStateProvince {
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
	public bool Active {
        get;
        set;
    }
	public Position Position {
        get;
        set;
    }
	public string NickName {
        get;
        set;
    }
	public string Gender {
        get;
        set;
    }
	public bool IsPlayer {
        get;
        set;
    }
	public bool IsVerified {
        get;
        set;
    }
    public string DraftYear {
        get;
        set;
    }
	public string MLBDebutDate {
        get;
        set;
    }
	public string BatSide {
        get;
        set;
    }
	public string PitchHand {
        get;
        set;
    }
}