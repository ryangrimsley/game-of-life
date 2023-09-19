using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private static int SCREEN_WIDTH = 48;
    private static int SCREEN_HEIGHT = 48;
    public Cell cellToUse;
    public float timerSpeed = 0.1f;
    private float timer = 0;
    public int cellChanceToSpawn = 80;
    public bool isGameStart = false;
    public bool isManualPlacing = false;

    Cell[,] grid = new Cell[SCREEN_WIDTH, SCREEN_HEIGHT];

    // Start is called before the first frame update
    void Start()
    {
        PlaceCells();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGameStart = true;
        }
        if (isManualPlacing)
        {
            if (isGameStart)
            {
                if (timer >= timerSpeed)
                {
                    CountNeighbors();

                    ControlPopulation();
                    timer = 0f;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
        if (isManualPlacing == false)
        {
            if (timer >= timerSpeed)
            {
                CountNeighbors();

                ControlPopulation();
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    void PlaceCells()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                Cell cell = Instantiate(cellToUse, new Vector2(x, y), cellToUse.transform.rotation);
                grid[x, y] = cell;
                if (isManualPlacing == true)
                {
                    grid[x, y].SetAlive(false);
                }
                if (isManualPlacing == false)
                {
                    grid[x, y].SetAlive(RandomAliveCell());
                }
            }
        }
    }
    bool RandomAliveCell()
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand < cellChanceToSpawn)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    void CountNeighbors()
    {
        
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                int numNeighbors = 0;

                //north
                if (y +1 < SCREEN_HEIGHT)
                {
                    if (grid[x, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //south
                if (y-1 >= 0)
                {
                    if (grid[x, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //east
                if (x+1 < SCREEN_WIDTH)
                {
                    if (grid[x+1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //west
                if (x - 1 >= 0)
                {
                    if (grid[x-1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //southeast
                if (y - 1 >= 0 && x + 1 < SCREEN_WIDTH)
                {
                    if (grid[x+1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //northeast
                if(y +1 < SCREEN_HEIGHT && x + 1 < SCREEN_WIDTH)
                {
                    if (grid[x + 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //southwest
                if(y - 1 >= 0 && x - 1 >= 0)
                {
                    if (grid[x - 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //northwest
                if(y + 1 < SCREEN_HEIGHT && x - 1 >= 0)
                {
                    if (grid[x - 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                grid[x, y].numNeighbors = numNeighbors;
                

            }
        }
        
    }

    void ControlPopulation()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                //cell is alive
                if (grid[x, y].isAlive)
                {
                    if (grid[x, y].numNeighbors != 2 && grid[x, y].numNeighbors != 3)
                    {
                        grid[x, y].SetAlive(false);
                    }
                }
                //cell is dead
                else
                {
                    if (grid[x, y].numNeighbors == 3)
                    {
                        grid[x, y].SetAlive(true);
                    }
                }
                
            }
        }
    }
}
