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
        EMPTY = 0,
        YELLOW = 55,
        GREEN = YELLOW + 30,
        BLUE = GREEN + 12,
        RED = BLUE + 3
    }

    private Sector[,] sectors;
    [SerializeField] private Vector2Int size = new Vector2Int(2, 2);

    //System display sprites
    public Sprite emptySystem;

    public Sprite yellowSystem;
    public Sprite greenSystem;
    public Sprite blueSystem;
    public Sprite redSystem;

    [SerializeField] private GameObject tilePrefab;


    void Start()
    {
        sectors = new Sector[size.x, size.y];
        
        for(int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                sectors[i, j] = new Sector();
                for(int y = 0; y < 4; y++)
                {
                    for(int x = 0; x < 4; x++)
                    {
                        GameObject newTile = Instantiate(tilePrefab, new Vector3((i - size.x/2) * 4f + ((float)x/size.x*2f), (j - size.y / 2) * 4f + ((float)y /size.y*2f) + 1, 0), Quaternion.identity);
                        //newTile.transform.localScale = newTile.transform.localScale * (1f/((size.x+size.y)/2f));
                        SpriteRenderer renderer = newTile.GetComponent("SpriteRenderer") as SpriteRenderer;
                        SystemType theSystem = SystemType.EMPTY;
                        foreach (StarSystem sys in sectors[i, j].getSystems())
                        {
                            if(sys.getPosition().x == x && sys.getPosition().y == y)
                            {
                                print(sys.getType());
                                theSystem = sys.getType();
                                sys.tile = newTile;
                            }
                        }
                        /*switch (theSystem)
                        {
                            case SystemType.YELLOW:
                                renderer.sprite = yellowSystem;
                                break;

                            case SystemType.GREEN:
                                renderer.sprite = greenSystem;
                                break;

                            case SystemType.BLUE:
                                renderer.sprite = blueSystem;
                                break;

                            case SystemType.RED:
                                renderer.sprite = redSystem;
                                break;

                            case SystemType.EMPTY:
                                renderer.sprite = emptySystem;
                                break;
                        }*/
                    }
                }
            }
        }
    }

    private void Update()
    {
    }
}
