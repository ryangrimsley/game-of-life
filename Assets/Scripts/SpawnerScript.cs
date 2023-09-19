using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject lightSquare;
    public GameObject darkSquare;
    public Color lightColor;
    public Color darkColor;
    int boardLength = 8;
    private void Start()
    {
        SpriteRenderer Lrend = lightSquare.GetComponent<SpriteRenderer>();
        SpriteRenderer Drend = darkSquare.GetComponent<SpriteRenderer>();
        for (int row = 0; row < boardLength; row++)
        {
            for (int col = 0; col < boardLength; col++)
            {
                if ((row + col) % 2 == 0)
                {
                    Instantiate(lightSquare, new Vector3(row - 3.5f, col - 3.5f, 0), transform.rotation);
                    Lrend.sharedMaterial.color = lightColor;
                }
                else
                {
                    Instantiate(darkSquare, new Vector3(row - 3.5f, col - 3.5f, 0), transform.rotation);
                    Drend.sharedMaterial.color = darkColor;
                }
            }
        }
    }
}
