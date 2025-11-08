namespace gridplauge;

public static class GameData
{
    public static bool Quit = false;
    public static bool HouseScene = false;
    public static int? House = null;
    public static int QuarantineSize = 4;
    public static int Days = 1;
    public static bool BorderClosed = false;
    public static Citizens[] CitizenData = new Citizens[36];
}

public class Citizens 
{
    public string Name {get;set;}
    public int HouseNumber {get;set;}
    public double Temperature {get;set;}
    public bool Infected {get;set;}
    public bool InQuarantine {get;set;}
}