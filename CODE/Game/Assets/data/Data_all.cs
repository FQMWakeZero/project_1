using System.Collections;
using System.Collections.Generic;
using UnityEngine;






[CreateAssetMenu(fileName = "Data_all", menuName = "Inventory/Data_all")]  //创建快捷创建方法



public class Data_all : ScriptableObject
{
    /*
    public List<string> _data = new List<string>();
    
    public string _str;
    public int _int;
    public float _float;
    public string[] _strArray;
   */

    public List<Data_soldier> data_Soldiers = new List<Data_soldier>();
    
}

