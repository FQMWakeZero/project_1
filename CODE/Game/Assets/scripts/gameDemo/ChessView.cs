using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class ChessView : MonoBehaviour
{
    public int GridX;
    public int GridY;

    public char direction;

    public GameObject soldier;
    public GameObject building;

    public Sprite[] playerSprite = new Sprite[4];
    public Sprite[] SpriteTexture = new Sprite[3];

    public MainLoop mainloop;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void put_display()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[0];
    }
    public void put_display(Soldier soldier, int put_x, int put_y)
    {
        
        
        var chessBoard_num = PlayerPrefs.GetInt("chessBoard_num", 3);

        if(chessBoard_num == 1)
        {
            if(mainloop.boardManager.GetNowPoint(GridX, GridY).GridX <= 9)// GridX <= 9
            {
                if (mainloop.boardManager.GetNowPoint(GridX, GridY).type == ChessType.None)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[1];
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[0];
                }
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[0];
            }


        }
        else
        {
            if(mainloop.boardManager.GetNowPoint(GridX, GridY).chessBoard_id == 1)
            {
                if (mainloop.boardManager.GetNowPoint(GridX, GridY).type == ChessType.None)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[1];
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[0];
                }
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[0];
            }
        }
        //Data_soldier data_Soldier;
        //data_Soldier = mainloop.findData.find_soldier(soldier_id);

        for (int i = 0; i < soldier.damage_x.Count; i++)
        {
            int x = 0, y = 0;
            if (soldier.direction == 'N')
            {
                x = put_x + soldier.damage_x[i];
                y = put_y - soldier.damage_y[i];
            }
            else if(soldier.direction == 'S')
            {

                x = put_x - soldier.damage_x[i];
                y = put_y + soldier.damage_y[i];
            }
            else if (soldier.direction == 'E')
            {
                x = put_x + soldier.damage_y[i];
                y = put_y + soldier.damage_x[i];
            }
            else if (soldier.direction == 'W')
            {
                x = put_x - soldier.damage_y[i];
                y = put_y - soldier.damage_x[i];
            }
            if (x == GridX && y == GridY)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[2];
                break;
            }
        }

    }


    public void display()
    {
        
        SpriteTexture[0] = playerSprite[mainloop.boardManager.GetNowPoint(GridX, GridY).player];
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[0];
        this.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        if (building)
        {
            foreach (Transform child in gameObject.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            var obj = GameObject.Instantiate<GameObject>(building);
            obj.transform.position = this.transform.position;
            obj.transform.parent = gameObject.transform;
        }
        else if (soldier)
        {
            foreach (Transform child in gameObject.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            var obj = GameObject.Instantiate<GameObject>(soldier);
            obj.transform.position = this.transform.position;
            obj.transform.parent = gameObject.transform;
        }
        else
        {
            foreach (Transform child in gameObject.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        if (direction == 'N')
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (direction == 'S')
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }
        else if (direction == 'E')
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 270f);
        }
        else if (direction == 'W')
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
