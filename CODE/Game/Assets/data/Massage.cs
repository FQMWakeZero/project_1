using System.Collections;
using System.Collections.Generic;
using UnityEngine;






[CreateAssetMenu(fileName = "massage", menuName = "Inventory/massage")]  //创建快捷创建方法



public class Massage : ScriptableObject
{
    /*
    public List<string> _data = new List<string>();
    
    public string _str;
    public int _int;
    public float _float;
    public string[] _strArray;
   */


    public ChessType type;
    public bool is_Magic;

    public bool is_putting;


    public int putting_chessBoard_id;
    public int putting_x;
    public int putting_y;

    public int last_chessBoard_id;
    public int last_x;
    public int last_y;

    public int moving_chessBoard_id;
    public int moving_x;
    public int moving_y;

    public int playerID;
    public Soldier soldier;


    
}

