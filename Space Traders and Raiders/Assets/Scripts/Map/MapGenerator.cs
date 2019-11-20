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
    [SerializeField] private Texture2D[] planets;


    // public Texture2D emptySystem;
    //
    // public Texture2D yellowSystem;
    // public Texture2D greenSystem;
    // public Texture2D blueSystem;
    // public Texture2D redSystem;


    [SerializeField] private GameObject tilePrefab;
    public GameObject planetUI;

    static private float ColorOverlayOpacity = .1f;
    static private float ColorOverlayBorderOpacity = .5f;
    static private int   Borderthickness = 3;
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
                        foreach (StarSystem sys in sectors[i, j].getSystems()) {
                            if(sys.getPosition().x == x && sys.getPosition().y == y)
                            {
                                theSystem = sys.getType();
                                sys.tile = newTile;
                            }
                        }

                        if(theSystem != SystemType.EMPTY){
                          SelectableSystem ss = newTile.AddComponent(typeof(SelectableSystem)) as SelectableSystem;
                          ss.planetUI = this.planetUI;
                          Texture2D col = new Texture2D(132, 132, TextureFormat.RGBA32, false);


                          Color c = new Color(0f, 0f, 0f, ColorOverlayOpacity);
                          switch(theSystem){
                            case SystemType.YELLOW:
                              c.r = 1f;
                              c.g = 1f;
                            break;

                            case SystemType.RED:
                              c.r = 1f;
                            break;

                            case SystemType.BLUE:
                              c.b = 1f;
                            break;

                            case SystemType.GREEN:
                              c.g = 1f;
                            break;
                          }
                          Color cb = new Color(c.r, c.g, c.b, ColorOverlayBorderOpacity);
                          for(int yT = 0; yT < col.height; yT ++){
                            for(int xT = 0; xT < col.width; xT ++){
                              if(yT < Borderthickness || yT > col.height - Borderthickness || xT < Borderthickness || xT > col.width - Borderthickness){
                                col.SetPixel(xT, yT, cb);
                              } else {
                                col.SetPixel(xT, yT, c);
                              }
                            }
                          }
                          col.Apply();

                          Texture2D tex = ImageHelpers.AlphaBlend(planets[Random.Range(0, planets.Length)], col);

                          renderer.sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(.5f, .5f), 128);
                        } else {
                          Color c = new Color(1f, 1f, 1f, ColorOverlayOpacity);
                          Color cb = new Color(1f, 1f, 1f, ColorOverlayBorderOpacity);
                          Texture2D col = new Texture2D(128, 128, TextureFormat.RGBA32, false);
                          for(int yT = 0; yT < col.height; yT ++){
                            for(int xT = 0; xT < col.width; xT ++){
                              if(yT < Borderthickness || yT > col.height - Borderthickness || xT < Borderthickness || xT > col.width - Borderthickness){
                                col.SetPixel(xT, yT, cb);
                              } else {
                                col.SetPixel(xT, yT, c);
                              }
                            }
                          }
                          col.Apply();
                          renderer.sprite = Sprite.Create(col, new Rect(0f, 0f, col.width, col.height), new Vector2(.5f, .5f), 128);
                          // renderer.color = ;
                        }
                    }
                }
            }
        }
    }

    private void Update()
    {
    }
}
