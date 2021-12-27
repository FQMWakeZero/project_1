using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class Ray : MonoBehaviour
{
    public RaycastHit2D[] hits;
    void Start()
    {
        
    }


    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
    }
}
