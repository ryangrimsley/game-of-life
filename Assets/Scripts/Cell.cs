using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isAlive = false;
    public int numNeighbors = 0;
    public Game game;

    public void OnMouseOver()
    {
        if (game.isManualPlacing == true)
        {
            if (game.isGameStart == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SetAlive(true);
                }
            }
        }
        
    }
    public void SetAlive(bool alive)
    {
        isAlive = alive;
        if (alive)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
