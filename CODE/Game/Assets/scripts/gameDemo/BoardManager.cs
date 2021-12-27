using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///棋盘管理
///创造棋盘，记录棋盘
/// </summary>
public class BoardManager : MonoBehaviour
{
    int i, j, k;
    float x, y;

    int chessBoard_num;
    int display_chessBoard_id = 1;
    public GameObject _box_Empty;
    public GameObject _chessbox;
    public GameObject _chessframe;
    public GameObject _Point;
    public GameObject _last;
    public MainLoop mainLoop;

    Dictionary<int,Dictionary<int, ChessPoint>> _chessPiont_list = new Dictionary<int,Dictionary<int, ChessPoint>>();
    Dictionary<int, Dictionary<int, ChessPoint>> _last_chessPiont_list = new Dictionary<int, Dictionary<int, ChessPoint>>();

    Dictionary<int, ChessView> _chessView = new Dictionary<int, ChessView>();
    //Dictionary<int, ChessPoint> _chessPiont = new Dictionary<int, ChessPoint>();
    //Dictionary<int, ChessPoint> _last_chessPiont = new Dictionary<int, ChessPoint>();
    void Start()
    {

        chessBoard_num = PlayerPrefs.GetInt("chessBoard_num",3);
        create_chessBoard();
    }
    
    public void change_display_chessBoard_id(int id)
    {
        display_chessBoard_id = id;
    }

    public void display_chessBoard()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.GetComponent<chessbox_index>())
            {
                if (child.gameObject.GetComponent<chessbox_index>().chessbox_id == display_chessBoard_id)
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
            
            
        }
    }

    public void display_chessBoard(int id)
    {
        display_chessBoard_id = id;

        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.GetComponent<chessbox_index>())
            {
                if (child.gameObject.GetComponent<chessbox_index>().chessbox_id == display_chessBoard_id)
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }


        }
    }



    public void create_chessBoard()
    {

        //_chessPiont.Clear();
        //_last_chessPiont.Clear();

        x = -4.5f;
        y = 8.5f;
        var Empty = GameObject.Instantiate<GameObject>(_chessbox);
        Empty.transform.localPosition = new Vector3(4f, 0f, -2f);
        Empty.transform.parent = gameObject.transform;
        for (i = 0; i < 18; i++)
        {
            y = 8.5f;
            for (j = 0; j < 18; j++)
            {
                var chessframe = GameObject.Instantiate<GameObject>(_chessframe);
                chessframe.transform.localPosition = new Vector3(x, y, -1f);
                chessframe.transform.parent = Empty.transform;
                var chessView = chessframe.GetComponent<ChessView>();
                chessView.GridX = i + 1;
                chessView.GridY = j + 1;
                chessView.mainloop = mainLoop;
                _chessView.Add(MakeKey(i + 1, j + 1), chessView);


                y = y - 1f;
            }
            x = x + 1f;

        }


        for (k = 1;k <= chessBoard_num;k++)
        {

            Dictionary<int, ChessPoint> _chessPiont = new Dictionary<int, ChessPoint>();
            Dictionary<int, ChessPoint> _last_chessPiont = new Dictionary<int, ChessPoint>();

            var chessbox = GameObject.Instantiate<GameObject>(_box_Empty);
            chessbox.transform.localPosition = new Vector3(4f, 0f, -1f);
            chessbox.transform.parent = gameObject.transform;
            chessbox.GetComponent<chessbox_index>().chessbox_id = k;
            x = -4.5f;
            y = 8.5f;
            //_chessPiont.Clear();
            //_last_chessPiont.Clear();
            for (i = 0; i < 18; i++)
            {
                

                y = 8.5f;
                for (j = 0; j < 18; j++)
                {

                    var last = GameObject.Instantiate<GameObject>(_last);
                    last.transform.localPosition = new Vector3(x, y, -2f);
                    last.transform.parent = chessbox.transform;
                    var chessPiont = last.GetComponent<ChessPoint>();
                    chessPiont.chessBoard_id = k;
                    chessPiont.GridX = i + 1;
                    chessPiont.GridY = j + 1;
                    chessPiont.mainloop = mainLoop;
                    _last_chessPiont.Add(MakeKey(i + 1, j + 1), chessPiont);

                    var Point = GameObject.Instantiate<GameObject>(_Point);
                    Point.transform.localPosition = new Vector3(x, y, -2f);
                    Point.transform.parent = chessbox.transform;
                    chessPiont = Point.GetComponent<ChessPoint>();
                    chessPiont.chessBoard_id = k;
                    chessPiont.GridX = i + 1;
                    chessPiont.GridY = j + 1;
                    chessPiont.mainloop = mainLoop;
                    
                    _chessPiont.Add(MakeKey(i + 1, j + 1), chessPiont);

                   

                    y = y - 1f;
                }
                x = x + 1f;

            }

            //print(_chessPiont.Count);


            _chessPiont_list.Add(k, _chessPiont);
            //print(_chessPiont_list[k].Count);
            _last_chessPiont_list.Add(k, _last_chessPiont);
        }

        //_chessPiont.Clear();
        //_last_chessPiont.Clear();

        display_chessBoard();

        //print(_chessPiont_list[2].Count);
    }

    /*
    public void Reset()
    {
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        //var mainLoop = GetComponent<MainLoop>();

        _chessPiont.Clear();
        _last_chessPiont.Clear();
        x = -4.5f;
        y = 8.5f;
        
        for(i = 0; i < 18; i++)
        {
            y = 8.5f;
            for (j = 0; j < 18; j++)
            {
                var obj = GameObject.Instantiate<GameObject>(_chessframe);
                obj.transform.localPosition = new Vector3(x, y, -1f);
                obj.transform.parent = gameObject.transform;
                var chessView = obj.GetComponent<ChessView>();
                chessView.GridX = i + 1;
                chessView.GridY = j + 1;
                _chessView.Add(MakeKey(i + 1, j + 1), chessView);

                var last = GameObject.Instantiate<GameObject>(_last);
                last.transform.localPosition = new Vector3(x, y, -2f);
                last.transform.parent = gameObject.transform;
                var chessPiont = last.GetComponent<ChessPoint>();
                chessPiont.GridX = i + 1;
                chessPiont.GridY = j + 1;
                chessPiont.mainloop = mainLoop;
                _last_chessPiont.Add(MakeKey(i + 1, j + 1), chessPiont);

                var Point = GameObject.Instantiate<GameObject>(_Point);
                Point.transform.localPosition = new Vector3(x, y, -2f);
                Point.transform.parent = gameObject.transform;
                chessPiont = Point.GetComponent<ChessPoint>();
                chessPiont.GridX = i + 1;
                chessPiont.GridY = j + 1;
                chessPiont.mainloop = mainLoop;
                _chessPiont.Add(MakeKey(i + 1, j + 1), chessPiont);

                y = y - 1f;
            }
            x = x + 1f;

        }

    }
    
    */

    public void changeToLast(int gridX, int gridY)
    {
        print("EEE");
        ChessPoint chessPoint;
        ChessPoint last_chessPoint;
        chessPoint = GetNowPoint(gridX, gridY);
        last_chessPoint = GetLastPoint(gridX, gridY);

        chessPoint.soldier = last_chessPoint.soldier;

        chessPoint.player = last_chessPoint.player;

        chessPoint.type = last_chessPoint.type;

    }


    public void changeToNow(int gridX, int gridY)
    {
        print("EEE");
        ChessPoint chessPoint;
        ChessPoint last_chessPoint;
        chessPoint = GetNowPoint(gridX, gridY);
        last_chessPoint = GetLastPoint(gridX, gridY);

        last_chessPoint.soldier = chessPoint.soldier;

        last_chessPoint.player = chessPoint.player;

        last_chessPoint.type = chessPoint.type;
    }


    public ChessView GetView(int gridX, int gridY)
    {
        ChessView chessview;
        if (_chessView.TryGetValue(MakeKey(gridX, gridY), out chessview))
        {
            return chessview;
        }
        return null;
    }
    public ChessPoint GetNowPoint(int gridX, int gridY)
    {
        ChessPoint chessPoint;

        Dictionary<int, ChessPoint> chessPoint_list;

        if (_chessPiont_list.TryGetValue(display_chessBoard_id, out chessPoint_list))
        {
            if (chessPoint_list.TryGetValue(MakeKey(gridX, gridY), out chessPoint))
            {
                return chessPoint;
            }

        }
        return null;
    }
    public ChessPoint GetNowPoint(int gridX, int gridY, int chessBoard_id)
    {
        ChessPoint chessPoint;

        Dictionary<int, ChessPoint>chessPoint_list;

        

        if (_chessPiont_list.TryGetValue(chessBoard_id, out chessPoint_list))
        {

            //print(chessPoint_list.Count);
            if (chessPoint_list.TryGetValue(MakeKey(gridX, gridY), out chessPoint))
            {
                //print(chessPoint);
                return chessPoint;
            }
                
        }
        
        return null;
    }

    public ChessPoint GetLastPoint(int gridX, int gridY)
    {
        ChessPoint chessPoint;

        Dictionary<int, ChessPoint> chessPoint_list;

        if (_last_chessPiont_list.TryGetValue(display_chessBoard_id, out chessPoint_list))
        {
            if (chessPoint_list.TryGetValue(MakeKey(gridX, gridY), out chessPoint))
            {
                return chessPoint;
            }

        }
        return null;
    }
    public ChessPoint GetLastPoint(int gridX, int gridY, int chessBoard_id)
    {
        ChessPoint chessPoint;

        Dictionary<int, ChessPoint> chessPoint_list;



        if (_last_chessPiont_list.TryGetValue(chessBoard_id, out chessPoint_list))
        {

            //print(chessPoint_list.Count);
            if (chessPoint_list.TryGetValue(MakeKey(gridX, gridY), out chessPoint))
            {
                //print(chessPoint);
                return chessPoint;
            }

        }

        return null;
    }


    public  int MakeKey(int x ,int y)
    {
        return x * 100 + y;
    }
}

public class Dictionary
{
}