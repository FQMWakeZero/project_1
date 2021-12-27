using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_in_out : MonoBehaviour
{
    int flame = 0;
    int in_out_state = 0;
    int max_transparency_flame = 0;
    float transparency = 0;
    public int speed = 1;
    public int duration_flame = 100;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, (float)0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        flame++;
        if (in_out_state  == 0)
        {
            if (flame % speed == 0)
            {
                transparency++;
                transform.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, transparency / 255);
                if (transparency == 255)
                {
                    max_transparency_flame = 1;
                    in_out_state = 1;
                }
            }
        }
        else if (max_transparency_flame > 0 && max_transparency_flame < duration_flame)
        {
            max_transparency_flame++;
            if (max_transparency_flame == duration_flame)
            {

                in_out_state = 2;
            }
        }
        else if(in_out_state == 2)
        {
            if (flame % speed == 0)
            {
                transparency--;
                transform.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, transparency / 255);

            }
        }
        


    }
}
