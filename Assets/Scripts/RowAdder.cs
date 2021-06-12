using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RowAdder : MonoBehaviour
{
    public GameObject piece;
    public Transform container;
    public Material[] materials;
    [Tooltip("Currently in place because of sizing, remove if no longer required")]
    public float temporaryOffset = 0.5f;
    
    private int numColumns = 9;
    
    void Start()
    {
        GenerateRow();
    }

    private void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            GenerateRow();
        }
    }

    public void GenerateRow()
    {
        List<Colors> colors = new List<Colors>();
        List<GameObject> objects = new List<GameObject>();

        container.position = new Vector3(container.position.x, container.position.y + 1, container.position.z);

        // Create (numColumn) cubes and place them in the row
        for (int i = 0; i < numColumns; ++i)
        {
            Vector3 nextPos = transform.position;
            nextPos.x += i;
            nextPos.x += temporaryOffset;

            int color = Random.Range(0, 4);
            var obj = Instantiate(piece, nextPos, Quaternion.identity);
            obj.GetComponent<Renderer>().material = materials[color];
            obj.transform.parent = container;

            objects.Add(obj);
            // obj.SetActive(true);

            colors.Add((Colors)color);
        }

        foreach(var obj in objects)
        {
            obj.SetActive(true);
        }

        GameState.AddRow(colors);
        return;
    }
}
