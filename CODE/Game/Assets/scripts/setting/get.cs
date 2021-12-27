using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class get : MonoBehaviour
{
    public Sprite[] SpriteTexture = new Sprite[3];
    int flame = 0;
    state state_;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[2];
    }


    void FixedUpdate()
    {
        flame++;


        

        state_ = GameObject.Find("Main Camera").GetComponent<state>();

        if (flame > 1000)
        {
            state_.i = 1;
        }

        if (state_.i == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[0];
        }
        else if (state_.i == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[1];
        }
        else if (state_.i == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTexture[2];
        }
    }
}
