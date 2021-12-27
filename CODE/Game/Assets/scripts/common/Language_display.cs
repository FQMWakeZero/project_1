using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ʾ������
/// </summary>
public class Language_display : MonoBehaviour
{
    public Sprite English;
    public Sprite Chinese;

    string Language;

    void Start()
    {

        //PlayerPrefs.SetString("Language", "Chinese");


        Language = PlayerPrefs.GetString("Language", "English");
        if (Language == "English")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = English;
        }
        else if (Language == "Chinese")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Chinese;
        }


    }


}
