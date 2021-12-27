using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class Add_Tag : MonoBehaviour
{
    public List<string> _Tag = new List<string>();
    void Start()
    {

        for (int i = 0; i < _Tag.Count; i++)
        {
            gameObject.tag = _Tag[i];
        }
        
    }


    void Update()
    {
        
    }
}
