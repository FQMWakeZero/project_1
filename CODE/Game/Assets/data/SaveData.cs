using System.Collections;
using System.Collections.Generic;
using UnityEngine;






[CreateAssetMenu(fileName = "New data", menuName = "Inventory/data")]  //创建快捷创建方法



public class SaveData : ScriptableObject
{
    /*
    public List<string> _data = new List<string>();
    
    public string _str;
    public int _int;
    public float _float;
    public string[] _strArray;
   */

    public GameObject gameObject;
    public string saveName;
    public int Id;
    
}

