using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem
{
    public enum SystemType
    {
        YELLOW = 55, GREEN = 30, BLUE = 12, RED = 3
    }

    private Vector2Int position = Vector2Int.zero;

    private SystemType type;

    // Start is called before the first frame update
    void Start()
    {
        int prob = Random.Range(1, 100);
        if(prob <= (int)SystemType.YELLOW)
        {
            this.type = SystemType.YELLOW;
        } else if (prob <= (int)SystemType.GREEN)
        {
            this.type = SystemType.GREEN;
        } else if (prob <= (int)SystemType.BLUE)
        {
            this.type = SystemType.BLUE;
        } else if (prob <= (int)SystemType.RED)
        {
            this.type = SystemType.RED;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool setPosition(int x, int y)
    {
        bool hasSet = false;
        if(x >= 0 && y >= 0)
        {
            position.Set(x, y);
            hasSet = true;
        }

        return hasSet;
    }

    public bool setPosition(Vector2Int v)
    {
        bool hasSet = false;
        if (v.x >= 0 && v.y >= 0)
        {
            position.Set(v.x, v.y);
            hasSet = true;
        }

        return hasSet;
    }

    public Vector2Int getPosition()
    {
        return this.position;
    }
}
