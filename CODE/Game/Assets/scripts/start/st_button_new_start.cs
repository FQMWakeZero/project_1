using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class st_button_new_start : MonoBehaviour
{

    bool hit_button = false;

    void OnMouseDown()
    {

        hit_button = true;

    }


    void OnMouseUp()
    {
        if (hit_button)
        {
            Invoke("click_botton_do", 0.5f);

        }
        hit_button = false;
    }

    private void click_botton_do()
    {

        //what you do

    }

}
