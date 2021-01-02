using System.Collections.Generic;

public static class GameState
{
    public static List<List<Colors>> rows;
    public static float fallSpeed;
    public static float maxFallSpeed;
    public static int piecesSpawned; // Dictates how fast we should fall

    static GameState()
    {
        rows = new List<List<Colors>>();
        fallSpeed = 0.25f;
        maxFallSpeed = 0.01f;
        piecesSpawned = 0;
    }
}

public enum Colors
{ 
    Red,
    Green,
    Blue,
    Yellow
};