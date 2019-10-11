using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //Store the probability of different system counts
    public enum SystemCount
    {
        TWOSYS = 80,
        THREESYS = TWOSYS + 15,
        ONESYS = THREESYS + 5
    }
    public enum SystemType
    {
        YELLOW = 55,
        GREEN = YELLOW + 30,
        BLUE = GREEN + 12,
        RED = GREEN + 3
    }

    private Sector[,] sectors;
    [SerializeField] private Vector2Int size = new Vector2Int(2, 2);

    //System display sprites
    public Sprite emptySystem;

    public Sprite yellowSystem;
    public Sprite greenSystem;
    public Sprite blueSystem;
    public Sprite redSystem;


    void Start()
    {
        sectors = new Sector[size.x, size.y];
        for(int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                sectors[i, j] = new Sector();
            }
        }
    }

    private void Update()
    {
    }
}
