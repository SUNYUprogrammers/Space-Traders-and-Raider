using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeCenter_Class : Facilities_Class
{
    public int[] x, y;

    public GameManager gm;

    // Start is called before the first frame update
    new public void Start()
    {
        base.Start();

        gm = GameObject.FindObjectOfType<GameManager>();

        type = 4;
        tier = 2;                                       //Set to two for sake of example, should start at 1 in actual game

        calcArea();
    }

    // Update is called once per frame
    new public void Update()
    {
        
    }

    override public string getTypeString()
    {
        return "Trade Center";
    }

    public void calcArea()
    {
        int i,j;

        //print("Tier is " + tier + " " + ( Mathf.Pow((float)(2*(tier-1)+1),2) ) );

        x = new int[(int)(2 * (tier - 1) + 1)];            //1 3  5  7
        y = new int[(int)(2 * (tier - 1) + 1)];            

        //x = new int[(int)Mathf.Pow((float)(2 * (tier - 1) + 1), 2)];            
        //y = new int[(int)Mathf.Pow((float)(2 * (tier - 1) + 1), 2)];            //1 9 25 49

        if (tier == 1)
        {
            x[0] = (int)tile.position.x;
            y[0] = (int)tile.position.y;
        }
        else
        {
            for (i = -(tier-1); i < (tier-1)+1; i++)
            {
                for (j = -(tier-1); j < (tier-1)+1; j++)
                {
                    //print(i+", "+j);

                    if (gm.x_min > ((int)tile.position.x+i) || ((int)tile.position.x+i) > gm.x_max)
                    {
                        print((int)tile.position.x + i + " is out of bounds");
                        if ((int)tile.position.x + i < gm.x_min)
                        {
                            x[i+(tier-1)] = (int)tile.position.x + i - gm.x_min + gm.x_max +1;
                        }
                        if ((int)tile.position.x + i > gm.x_max)
                        {
                            x[i + (tier-1)]  = (int)tile.position.x + i - gm.x_max + gm.x_min -1;
                        }
;                   }
                    else
                    {
                        x[i + (tier-1)] = (int)tile.position.x + i;
                    }
                    if (gm.y_min > ((int)tile.position.y + j) || ((int)tile.position.y + j) > gm.y_max)
                    {
                        print((int)tile.position.y + j + " is out of bounds");
                        if ((int)tile.position.y + j < gm.y_min)
                        {
                            y[j + (tier-1)] = (int)tile.position.y + j - gm.y_min + gm.y_max +1;
                        }
                        if ((int)tile.position.y + j > gm.y_max)
                        {
                            y[j + (tier-1)] = (int)tile.position.y + j - gm.y_max + gm.y_min -1;
                        }
;
                    }
                    else
                    {
                        //print(j + (tier-1));
                        y[j + (tier-1)] = (int)tile.position.y + j;
                    }
                    //print("X " + x[i + (tier-1)] + ", Y " + y[j + (tier-1)]);
                    GameObject temp = Instantiate((GameObject)Resources.Load("HomeSystem"), new Vector3(x[i+(tier-1)],y[j+(tier-1)],0), new Quaternion());
                    temp.GetComponent<SpriteRenderer>().color = self;
                }
            }
        }
    }
}
