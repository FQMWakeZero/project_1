using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class Soldier_Move : MonoBehaviour
{
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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (ray.hits.Length > 0)
        {
            foreach (RaycastHit2D Hit2D in ray.hits)
            {

                if (Hit2D.collider.GetComponent<ChessPoint>() && Hit2D.collider.GetComponent<ChessPoint>().type == ChessType.None)
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
        else
        {
            this.transform.position = new Vector3(mousePos.x, mousePos.y, -5f);
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            direction = 'N';

            mainloop.View_put_display();
        }

    }

}
