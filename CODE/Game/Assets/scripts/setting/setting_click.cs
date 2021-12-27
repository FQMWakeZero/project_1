using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///点击传值给setting_state
/// </summary>
public class setting_click : MonoBehaviour
{
    public int myIndex = 1;
    private bool hit_button = false;
    void Start()
    {
        
    }


    void OnMouseDown()
    {

        hit_button = true;

    }


    void OnMouseUp()
    {

        if (hit_button)
        {
            GameObject.Find("Main Camera").GetComponent<setting_state>().State = myIndex;

        }

        hit_button = false;
    }
}
