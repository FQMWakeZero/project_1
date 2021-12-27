using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class BoxView : MonoBehaviour
{
    public int chessbox_id = 1;
    public Sprite[] SpriteTexture = new Sprite[3];


    void Start()
    {

        display();
    }

    public void display(int id)
    {
        chessbox_id = id;
        display();
    }
    public void display()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[chessbox_id-1];
    }
}
