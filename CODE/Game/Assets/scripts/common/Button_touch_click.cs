using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class Button_touch_click : MonoBehaviour
{
    public Sprite[] SpriteTexture = new Sprite[3];
    bool click = false;
    bool hit_button = false;
    int button_state = 0;

    void OnMouseEnter()
    {
        hit_button = true;

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);

        if (click)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[2];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[1];
        }
    }

    void OnMouseExit()
    {
        hit_button = false;

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);

        if (click)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[2];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[0];
        }
    }

    void OnMouseDown()
    {
        click = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[2];
    }

    void OnMouseUp()
    {
        click = false;
        if (hit_button)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[1];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[0];
        }
    }
}
