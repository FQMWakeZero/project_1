using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///棋盘信息
///记录棋盘信息，响应点击
/// </summary>
/// 

public enum ChessType
{
    None = 0,
    Soldier = 1,
    Building = 2,

}
public class ChessPoint : MonoBehaviour
{
    public int chessBoard_id;
    public int GridX;
    public int GridY;

    public int player;

    //public GameObject soldier;
    //public GameObject building;

    //public char direction;
    public ChessType type;

    public Soldier soldier;

    public MainLoop mainloop;

    public void OnMouseDown()
    {
        mainloop.OnChessPointChick(this);
        print("AAA");
    }
}
