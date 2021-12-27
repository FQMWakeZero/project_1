using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class FindData : MonoBehaviour
{
    public Data_all data_All;
    void Start()
    {

    }


    void Update()
    {

    }

    public Data_soldier find_soldier(int id)
    {


        foreach (Data_soldier data_Soldier in data_All.data_Soldiers)
        {
            if (data_Soldier.Id == id)
            {
                return data_Soldier;
            }
        }

        return null;
    }
}
