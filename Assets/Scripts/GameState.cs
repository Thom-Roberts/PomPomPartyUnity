using System.Collections.Generic;

public static class GameState
{
    // 0 is the bottom
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

    public static void AddRow(List<Colors> row)
    {
        rows.Insert(0, row);
        TestForMatch();

        return;
    }

    private static void TestForMatch()
    {
        for(int i = 0; i < rows.Count; i++)
        {
            var row = rows[i];
            for(int j = 0; j < row.Count; j++)
            {

            }
        }
    }
}

public enum Colors
{ 
    Red,
    Green,
    Blue,
    Yellow
};