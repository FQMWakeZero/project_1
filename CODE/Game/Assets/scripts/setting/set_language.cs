using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///设置语言并返回菜单
/// </summary>
public class set_language : MonoBehaviour
{
    public int languageIndex = 2;
    [SerializeField]
    private int now_languageIndex = 2;
    string Language;
    void Awake()
    {
        Language = PlayerPrefs.GetString("Language", "English");
        if (Language == "English")
        {
            languageIndex = 2;
            now_languageIndex = 2;
        }
        else if (Language == "Chinese")
        {
            languageIndex = 1;
            now_languageIndex = 1;
        }
    }


    void Update()
    {
        if(now_languageIndex != languageIndex)
        {
            if (languageIndex == 1)
            {
                PlayerPrefs.SetString("Language", "Chinese");
                Invoke("click_botton_do", 0.5f);
            }
            else if(languageIndex == 2)
            {
                PlayerPrefs.SetString("Language", "English");
                Invoke("click_botton_do", 0.5f);
            }
            now_languageIndex = languageIndex;
        }
    }

    private void click_botton_do()
    {

        SceneManager.LoadScene("start");

    }
}
