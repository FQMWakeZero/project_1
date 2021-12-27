using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class state : MonoBehaviour
{
    public int i;
    int flame = 0;
    void Start()
    {
        i = 2;
    }


    void FixedUpdate()
    {
        flame++;

    }
}
