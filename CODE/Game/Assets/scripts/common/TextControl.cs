using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///
/// </summary>
public class TextControl : MonoBehaviour
{
    string text;
    void Start()
    {
        text = "666";
        display_text();
    }
    public void display_text()
    {
        this.GetComponent<Text>().text = text;
    }
    public void display_text(string _text)
    {
        text = _text;
        display_text();
    }

}
