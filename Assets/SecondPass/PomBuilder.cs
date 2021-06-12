using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomBuilder : MonoBehaviour
{
    public Color[] colors;
    public SpriteRenderer[] spriteRenderers;

    private void Awake()
    {
        int id = Shader.PropertyToID("Desired_Color");

        foreach(SpriteRenderer sprite in spriteRenderers)
        {
            var colorIndx = Random.Range(0, colors.Length - 1);
            sprite.material.SetColor(id, colors[colorIndx]);
        }    
    }
}
