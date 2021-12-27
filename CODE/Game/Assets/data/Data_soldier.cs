using System.Collections;
using System.Collections.Generic;
using UnityEngine;






[CreateAssetMenu(fileName = "Data_soldier", menuName = "Inventory/Data_soldier")]  //创建快捷创建方法



public class Data_soldier : ScriptableObject
{
    /*
    public List<string> _data = new List<string>();
    
    public string _str;
    public int _int;
    public float _float;
    public string[] _strArray;
   */

    public GameObject card;
    public GameObject soldier;
    public string saveName;
    public int Id;
    
    
    public int life;
    public int armour;
    public int use_cereal;
    public int stay_cereal;
    public int damage;
    public int damage_way;
    public char move_way;
    public int move_step;

    public int buff_id;

    public List<int> damage_x;
    public List<int> damage_y;
    
}

