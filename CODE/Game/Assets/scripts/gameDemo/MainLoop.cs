using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///主要循环
///所有点击响应和传递信息
///！！！不能存储任何数值！！！
/// </summary>
public class MainLoop : MonoBehaviour
{
    //List<string> A = new List<string>();

    public Round round;
    public BoardManager boardManager;
    public CardManager cardManager;
    public Ray ray;
    public FindData findData;
    void Start()
    {
        //round = GameObject.Find("round").GetComponent<Round>();
        //boardManager = GetComponent<BoardManager>();
        //cardManager = GetComponent<CardManager>();
    }




    public void View_put_display() //复原
    {
        int x, y;
        for (x = 1; x <= 18; x++)
        {
            for (y = 1; y <= 18; y++)
            {
                boardManager.GetView(x, y).put_display();
            }
        }
    }
    public void View_put_display(Soldier soldier, int put_x, int put_y)
    {
        int x, y;
        for (x = 1; x <= 18; x++)
        {
            for (y = 1; y <= 18; y++)
            {
                View_put_display(soldier, put_x, put_y, x, y);
            }
        }
    }
    public void View_put_display(Soldier soldier, int put_x, int put_y, int gridX, int gridY) //士兵放置   ChessView 单个修改输出
    {
        boardManager.GetView(gridX, gridY).put_display(soldier, put_x, put_y);
    }
    public void ChessViewDisplay()
    {
        int x, y;
        for (x = 1; x <= 18; x++)
        {
            for(y = 1;y <= 18;y++)
            {
                ChessViewDisplay(x, y);
            }
        }
        
    }
    public void ChessViewDisplay(int gridX, int gridY) //显示士兵
    {
        //print(boardManager.GetNowPoint(gridX, gridY).soldier);
        

        if (boardManager.GetNowPoint(gridX, gridY).type == ChessType.Soldier)
        {
            boardManager.GetView(gridX, gridY).building = null;
            boardManager.GetView(gridX, gridY).soldier = boardManager.GetNowPoint(gridX, gridY).soldier.soldier;
            boardManager.GetView(gridX, gridY).direction = boardManager.GetNowPoint(gridX, gridY).soldier.direction;
        }
        else if(boardManager.GetNowPoint(gridX, gridY).type == ChessType.Building)
        {
            boardManager.GetView(gridX, gridY).soldier = null;
            //boardManager.GetView(gridX, gridY).building = boardManager.GetNowPoint(gridX, gridY).building;

        }
        
        else
        {
            boardManager.GetView(gridX, gridY).soldier = null;
            boardManager.GetView(gridX, gridY).building = null;
        }
        //boardManager.GetView(gridX, gridY).soldier = boardManager.GetNowPoint(gridX, gridY).soldier;
        //boardManager.GetView(gridX, gridY).building = boardManager.GetNowPoint(gridX, gridY).building;
        boardManager.GetView(gridX, gridY).display();
        
    }
    



    public void OnChessPointChick(ChessPoint chessPoint)
    {
        print("BBB");

        //boardManager.changeToLast();
        //int a = boardManager.GetPoint(chessPoint.GridX, chessPoint.GridY).data;
        //boardManager.GetPoint(chessPoint.GridX, chessPoint.GridY).data = 100;





        //A.Add("AAA");
        //print(A.Count); 
    }
    public void OnCardPointChick(CardPoint cardPoint)
    {
        print("BBB");
        //int a = cardManager.GetPoint(cardPoint.cardID).dataID;

        var obj = GameObject.Instantiate<GameObject>(cardPoint.soldier_put_E);
        var soldier_put = obj.GetComponent<Soldier_Put>();
        var soldier = new Soldier();

        Data_soldier data_Soldier;
        data_Soldier = findData.find_soldier(cardPoint.dataID);

        soldier.soldier = data_Soldier.soldier;
        soldier.Id = data_Soldier.Id;
        soldier.life = data_Soldier.life;
        soldier.now_life = data_Soldier.life;
        soldier.armour = data_Soldier.armour;
        soldier.stay_cereal = data_Soldier.stay_cereal;
        soldier.damage = data_Soldier.damage;
        soldier.damage_way = data_Soldier.damage_way;
        soldier.move_way = data_Soldier.move_way;
        soldier.move_step = data_Soldier.move_step;
        soldier.buff_id = data_Soldier.buff_id;
        soldier.damage_x = data_Soldier.damage_x;
        soldier.damage_y = data_Soldier.damage_y;

        soldier_put.soldier = soldier;

        soldier_put.mainloop = this;
        soldier_put.ray = ray;
        
        var s = GameObject.Instantiate<GameObject>(cardPoint.soldier);
        s.transform.parent = obj.transform;
        //A.Add("BBB");
        //print(A.Count);
    }
    public void OnSoldierPut(Massage massage)
    {
        print("CCC");
        round.massages.Add(massage);
    }
    
   public void set_soldier(int soldier_id,char direction, bool on_ownArea)
    {
        var chessBoard_num = PlayerPrefs.GetInt("chessBoard_num",2);
    }
    public void set_soldier(Soldier soldier, int player, int gridX, int gridY, int chessBoard_id)
    {
        boardManager.display_chessBoard(chessBoard_id);

        var chessPoint = boardManager.GetNowPoint(gridX, gridY, chessBoard_id);

        chessPoint.player = player;
        chessPoint.type = ChessType.Soldier;
        chessPoint.soldier = soldier;



        /*
        chessPoint.player = player;
        chessPoint.direction = direction;
        chessPoint.soldier = data_Soldier.soldier;
        chessPoint.type = ChessType.Soldier;
        chessPoint.life = data_Soldier.life;
        chessPoint.now_life = data_Soldier.life;
        chessPoint.stay_cereal = data_Soldier.stay_cereal;
        chessPoint.armour = data_Soldier.armour;
        chessPoint.damage = data_Soldier.damage;
        chessPoint.move_way = data_Soldier.move_way;
        chessPoint.move_step = data_Soldier.move_step;
        chessPoint.damage_x = data_Soldier.damage_x;
        chessPoint.damage_y = data_Soldier.damage_y;
        */

        ChessViewDisplay();
    }


    public void now_to_last()
    {
        int x, y;
        for (x = 1; x <= 18; x++)
        {
            for (y = 1; y <= 18; y++)
            {
                boardManager.changeToLast(x,y);
            }
        }
        ChessViewDisplay();
    }

    public void last_to_now()
    {
        int x, y;
        for (x = 1; x <= 18; x++)
        {
            for (y = 1; y <= 18; y++)
            {
                boardManager.changeToNow(x, y);
            }
        }
        ChessViewDisplay();
    }


}
