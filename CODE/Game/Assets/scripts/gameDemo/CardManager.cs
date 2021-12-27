using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///卡牌管理
///创造卡牌，记录卡牌
/// </summary>
public class CardManager : MonoBehaviour
{
    int i, j, k, m;
    float x, y;
    public Data_all data_All;
    public GameObject _gameObject;
    //public GameObject _Empty;
    public MainLoop mainLoop;
    public FindData findData;
    Dictionary<int, CardPoint> _cardPiont = new Dictionary<int, CardPoint>();
    void Start()
    {
        Reset();
    }
    public void Reset()
    {
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        //var mainLoop = GetComponent<MainLoop>();
        _cardPiont.Clear();
        x = -14f;
        y = 6f;
        k = 0;
        m = 0;
        foreach (Data_soldier data in data_All.data_Soldiers)
        {
            m++;
        }
        for (i = 0; i < 2; i++)
        {
            x = -14f;
            for (j = 0; j < 3; j++)
            {

                if (k >= m)
                {
                    break;
                }
                k++;
                
                var obj = GameObject.Instantiate<GameObject>(_gameObject);
                obj.transform.position = new Vector3(x, y, -1f);
                obj.transform.parent = gameObject.transform;
                var cardPiont = obj.GetComponent<CardPoint>();
                cardPiont.cardID = k;
                cardPiont.mainloop = mainLoop;

                
                Data_soldier data_Soldier;
                data_Soldier = findData.find_soldier(k);
                cardPiont.dataID = data_Soldier.Id;
                cardPiont.soldier = data_Soldier.soldier;
                var card = GameObject.Instantiate<GameObject>(data_Soldier.card);
                card.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, -2f);
                card.transform.parent = obj.transform;
                
                /*
                foreach (Data_soldier data in data_All.data_Soldiers)
                {
                    if (data.Id == k)
                    {
                        cardPiont.dataID = data.Id;
                        cardPiont.soldier = data.soldier;
                        var card = GameObject.Instantiate<GameObject>(data.card);
                        card.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, -2f);
                        card.transform.parent = obj.transform;
                    }
                }
                */


                _cardPiont.Add(k, cardPiont);
                x = x + 3f;
            }
            y = y - 4f;

        }
    }




    public CardPoint GetPoint(int cardID)
    {
        CardPoint cardPoint;
        if (_cardPiont.TryGetValue(cardID, out cardPoint))
        {
            return cardPoint;
        }
        return null;
    }
    void Update()
    {
        
    }
}
