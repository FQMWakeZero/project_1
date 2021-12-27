using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class set_language_click : MonoBehaviour
{
    public Sprite[] SpriteTexture = new Sprite[4];
    public int myIndex = 1;
    bool hit_button = false;
    int button_state = 0;
    void Start()
    {

        if (GameObject.Find("language_box").GetComponent<set_language>().languageIndex == myIndex)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[3];
        }
            
    }


    void Update()
    {
        /*
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        //Debug.Log(hit.collider.name);
        
        if (hit.collider.name == gameObject.name)
        {
            if (GameObject.Find("language_box").GetComponent<set_language>().languageIndex == myIndex)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[3];
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[1];
            }
        }
        else
        {
            if (GameObject.Find("language_box").GetComponent<set_language>().languageIndex == myIndex)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[2];
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[0];
            }
        }
        */

    }
    void OnMouseEnter()
    {
        if (GameObject.Find("language_box").GetComponent<set_language>().languageIndex == myIndex)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[3];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[1];
        }
    }
    void OnMouseExit()
    {
        if (GameObject.Find("language_box").GetComponent<set_language>().languageIndex == myIndex)
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

        hit_button = true;

    }


    void OnMouseUp()
    {

        if (hit_button)
        {
            GameObject.Find("language_box").GetComponent<set_language>().languageIndex = myIndex;

        }

        hit_button = false;
    }
}
