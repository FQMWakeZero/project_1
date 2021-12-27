using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class Click_button_sound : MonoBehaviour
{
    public AudioClip touch;
    public AudioClip click;

    float bottonSound;
    void Start()
    {
        bottonSound = PlayerPrefs.GetFloat("bottonSound", 1f);
        this.gameObject.GetComponent<AudioSource>().loop = false;
        this.gameObject.GetComponent<AudioSource>().volume = bottonSound;
    }

    void OnMouseEnter()
    {
        this.gameObject.GetComponent<AudioSource>().clip = touch;
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    void OnMouseDown()
    {
        this.gameObject.GetComponent<AudioSource>().clip = click;
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
