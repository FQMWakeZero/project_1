using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ļ
/// </summary>
public class Screen_settings : MonoBehaviour
{

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);

        Screen.fullScreen = true;  //���ó�ȫ��,
    }


    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Screen.fullScreen = false;
            }
        }
    }
}
