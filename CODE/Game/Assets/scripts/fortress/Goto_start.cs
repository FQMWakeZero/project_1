using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goto_start : MonoBehaviour
{

    int flame = 0;
    public int change_flame = 1000;

    void FixedUpdate()
    {
        flame++;
        if (flame > change_flame)
        {
            SceneManager.LoadScene("start");
        }
    }
}
