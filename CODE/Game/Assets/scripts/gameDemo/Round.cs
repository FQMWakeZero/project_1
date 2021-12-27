using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class Round : MonoBehaviour
{
    public List<Massage> massages = new List<Massage>();

    int AI_num;
    int chessBoard_num;
    public MainLoop mainloop;
    void Start()
    {
        AI_num = PlayerPrefs.GetInt("AI_num", 2);
        chessBoard_num = PlayerPrefs.GetInt("chessBoard_num", 3);
    }


    void Update()
    {
        
    }
    public void OnMouseUp()
    {
        print("EEE");
        mainloop.now_to_last();
        foreach (Massage massage in massages)
        {
            if (massage.type == ChessType.Soldier){
                if (massage.is_putting)
                {
                    mainloop.set_soldier(massage.soldier, massage.playerID, massage.putting_x, massage.putting_x, massage.putting_chessBoard_id);
                }
            }
        }
    }

}
