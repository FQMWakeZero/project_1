using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///������Ϣ
///��¼������Ϣ����Ӧ���
/// </summary>
/// 
/*
public enum CardType
{
    None = 0,
    Black = 1,
    White = 2,

}
*/
public class CardPoint : MonoBehaviour
{
    public int cardID;

    public Massage massage;

    public GameObject soldier_put_E;

    public GameObject soldier;

    public int dataID;

    public MainLoop mainloop;
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        mainloop.OnCardPointChick(this);
        print("AAA");
    }
    void Update()
    {
        
    }
}
