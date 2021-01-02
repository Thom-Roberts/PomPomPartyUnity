using System.Collections.Generic;

public static class GameState
{
    public static List<List<Colors>> rows;
    public static float fallSpeed;

    static GameState()
    {
        rows = new List<List<Colors>>();
        fallSpeed = 0.5f;
    }
}

public enum Colors
{ 
    Red,
    Green,
    Blue,
    Yellow
};