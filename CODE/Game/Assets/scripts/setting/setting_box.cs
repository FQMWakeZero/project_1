using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///ȡֵsetting_state ����뼺��ͬ����ʾ
/// </summary>
public class setting_box : MonoBehaviour
{
    public int myIndex = 1;
    void Start()
    {
        
    }


    void Update()
    {
        if(GameObject.Find("Main Camera").GetComponent<setting_state>().State == myIndex)
        {
            this.transform.position = new Vector3(3, 0, -1);
        }
        else
        {
            this.transform.position = new Vector3(3, 0, 2);
        }
    }
}
