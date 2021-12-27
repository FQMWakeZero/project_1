using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class Soldier_Put : MonoBehaviour
{
    public bool is_putting = false;
    //public Massage massage;
    //public int Soldier_id;
    char direction;
    public MainLoop mainloop;
    public Ray ray;
    public Soldier soldier;

    void Start()
    {
        
    }


    void Update()
    {

        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject)
            {
                child.transform.position = this.transform.position;
            }


        }
        /*
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
        */


        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //print(ray.hits.Length);
        var chessBoard_num = PlayerPrefs.GetInt("chessBoard_num", 3);

        if (ray.hits.Length > 0)
        {

            
            foreach (RaycastHit2D Hit2D in ray.hits)
            {

                if (chessBoard_num == 1)
                {
                    if (Hit2D.collider.GetComponent<ChessPoint>() &&
                        Hit2D.collider.GetComponent<ChessPoint>().type == ChessType.None && 
                        Hit2D.collider.GetComponent<ChessPoint>().GridX <= 9)
                    {

                        this.transform.position = new Vector3(Hit2D.collider.transform.position.x, Hit2D.collider.transform.position.y, -5f);

                        var x = mousePos.x - Hit2D.collider.transform.position.x;
                        var y = mousePos.y - Hit2D.collider.transform.position.y;
                        if (y > 0 && y > x && y > -x)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                            direction = 'N';
                        }
                        if (y < 0 && y < x && y < -x)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 0f, 180f);
                            direction = 'S';
                        }
                        if (x > 0 && y < x && y > -x)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 0f, 270f);
                            direction = 'E';
                        }
                        if (x < 0 && y > x && y < -x)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                            direction = 'W';
                        }
                        var chessPoint = Hit2D.collider.GetComponent<ChessPoint>();
                        soldier.direction = direction;
                        mainloop.View_put_display(soldier, chessPoint.GridX, chessPoint.GridY);
                    }
                    else
                    {
                        this.transform.position = new Vector3(mousePos.x, mousePos.y, -5f);
                        this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                        direction = 'N';

                        mainloop.View_put_display();
                    }
                }
                else
                {
                    if (Hit2D.collider.GetComponent<ChessPoint>() && 
                        Hit2D.collider.GetComponent<ChessPoint>().type == ChessType.None && 
                        Hit2D.collider.GetComponent<ChessPoint>().chessBoard_id == 1)
                    {

                        this.transform.position = new Vector3(Hit2D.collider.transform.position.x, Hit2D.collider.transform.position.y, -5f);

                        var x = mousePos.x - Hit2D.collider.transform.position.x;
                        var y = mousePos.y - Hit2D.collider.transform.position.y;
                        if (y > 0 && y > x && y > -x)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                            direction = 'N';
                        }
                        if (y < 0 && y < x && y < -x)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 0f, 180f);
                            direction = 'S';
                        }
                        if (x > 0 && y < x && y > -x)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 0f, 270f);
                            direction = 'E';
                        }
                        if (x < 0 && y > x && y < -x)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                            direction = 'W';
                        }
                        var chessPoint = Hit2D.collider.GetComponent<ChessPoint>();
                        soldier.direction = direction;
                        mainloop.View_put_display(soldier, chessPoint.GridX, chessPoint.GridY);
                    }
                    else
                    {
                        this.transform.position = new Vector3(mousePos.x, mousePos.y, -5f);
                        this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                        direction = 'N';

                        mainloop.View_put_display();
                    }
                }



            }

        }
        else
        {
            this.transform.position = new Vector3(mousePos.x, mousePos.y, -5f);
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            direction = 'N';
            
            mainloop.View_put_display();
        }




        /*
            if (mousePos.x > -5f && mousePos.x < 13f && mousePos.y > -9f && mousePos.y < 9f)
        {

            foreach (RaycastHit2D Hit2D in hits)
            {
                if (Hit2D.collider.GetComponent<ChessPoint>())
                {
                    this.transform.position = new Vector3(Hit2D.collider.transform.position.x, Hit2D.collider.transform.position.y, -5f);
                    var x = mousePos.x - Hit2D.collider.transform.position.x;
                    var y = mousePos.y - Hit2D.collider.transform.position.y;
                    if (y > 0 && y > x && y > -x)
                    {
                        this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                        direction = 'N';
                    }
                    if (y < 0 && y < x && y < -x)
                    {
                        this.transform.eulerAngles = new Vector3(0f, 0f, 180f);
                        direction = 'S';
                    }
                    if (x > 0 && y < x && y > -x)
                    {
                        this.transform.eulerAngles = new Vector3(0f, 0f, 270f);
                        direction = 'E';
                    }
                    if (x < 0 && y > x && y < -x)
                    {
                        this.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                        direction = 'W';
                    }
                }
            }
        }

            //        this.transform.position = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, -5f);
            //var x = mousePos.x - hit.collider.transform.position.x;
            //var y = mousePos.y - hit.collider.transform.position.y;
            /*
            if (y>0 && y > x && y > -x)
            {
                this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                direction = 'N';
            }
            if (y < 0 && y < x && y < -x)
            {
                this.transform.eulerAngles = new Vector3(0f, 0f, 180f);
                direction = 'S';
            }
            if (x > 0 && y < x && y > -x)
            {
                this.transform.eulerAngles = new Vector3(0f, 0f, 270f);
                direction = 'E';
            }
            if (x < 0 && y > x && y < -x)
            {
                this.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                direction = 'W';
            }

        }
        
        else
        {
                this.transform.position = new Vector3(mousePos.x, mousePos.y, -5f);
                this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                direction = 'N';
        }
        */
    }



    public void OnMouseDown()
    {
        /*
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
        */
        foreach(RaycastHit2D Hit2D in ray.hits)
        {
            if (Hit2D.collider.GetComponent<ChessPoint>())
            {
                var chessPoint = Hit2D.collider.GetComponent<ChessPoint>();
                if (mainloop.boardManager.GetNowPoint(chessPoint.GridX, chessPoint.GridY).type == ChessType.None)
                {
                    var massage = new Massage();
                    massage.type = ChessType.Soldier;
                    massage.is_Magic = false;
                    massage.is_putting = true;
                    massage.putting_chessBoard_id = chessPoint.chessBoard_id;
                    massage.putting_x = chessPoint.GridX;
                    massage.putting_y = chessPoint.GridY;
                    massage.playerID = 1;
                    //massage.Id = Soldier_id;

                    soldier.direction = direction;

                    massage.soldier = soldier;
                    mainloop.OnSoldierPut(massage);
                    
                    mainloop.set_soldier(soldier, 1, chessPoint.GridX, chessPoint.GridY, chessPoint.chessBoard_id);

                    /*
                    Data_soldier data_Soldier;
                    data_Soldier = findData.find_soldier(Soldier_id);
                    chessPoint.direction = direction;
                    chessPoint.soldier = data_Soldier.soldier;
                    chessPoint.is_Soldier = true;
                    chessPoint.is_Building = false;
                    chessPoint.life = data_Soldier.life;
                    chessPoint.now_life = data_Soldier.life;
                    chessPoint.stay_cereal = data_Soldier.stay_cereal;
                    chessPoint.armour = data_Soldier.armour;
                    chessPoint.damage = data_Soldier.damage;
                    chessPoint.move_way = data_Soldier.move_way;
                    chessPoint.move_step = data_Soldier.move_step;
                    chessPoint.damage_x = data_Soldier.damage_x;
                    chessPoint.damage_y = data_Soldier.damage_y;
                    */
                }


                
            }
        }
        

        Destroy(gameObject);
    }
}
