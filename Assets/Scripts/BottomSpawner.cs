using System.Collections.Generic;
using UnityEngine;

public class BottomSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    public Transform container;
    public float spawnTime = 15f;
    public float xOffset = 5f;

    private uint numSpawns = 0;

    void Start()
    {
        // Create 4 rows
        // SpawnRow();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            SpawnRow();
    }

    void SpawnRow()
    {
        List<Colors> row = new List<Colors>();
        // Shift others up
        container.position = new Vector3(container.position.x, container.position.y + 1, container.position.z);
        
        // Generate 8 random things
        for(int i = 0; i < 8; i++)
        {
            Colors color = GetRandomColor();
            Vector2 nextPosition = new Vector3(transform.position.x + xOffset * i, transform.position.y, transform.position.z);
            var created = Instantiate(ghostPrefab, nextPosition, Quaternion.identity);
            switch(color) {
                case Colors.Red:
                    break;
                case Colors.Green:
                    break;
                case Colors.Blue:
                    break;
                case Colors.Yellow:
                    break;
            };
            created.transform.parent = container.transform;

            row.Add(color);
        }

        GameState.rows.Add(row);
        numSpawns++;
        AdjustSpawnRate();
        Invoke(nameof(SpawnRow), spawnTime);
    }

    void AdjustSpawnRate()
    {
        // Should speed up over time
        // Test the numSpawns
    }

    Colors GetRandomColor()
    {
        return (Colors)Random.Range(0, System.Enum.GetValues(typeof(Colors)).Length);
    }
}
