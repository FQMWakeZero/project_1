using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class st_button_setting : MonoBehaviour
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

        SceneManager.LoadScene("setting");

    }
}
