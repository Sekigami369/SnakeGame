using System;
using System.Diagnostics;

public class Snake
{
    public static void Main(string[] args)
    {
        DateTime date = DateTime.Now;

        Random random = new Random();
        //foodの出現位置に使う乱数

        Console.WindowHeight = 32;
        Console.WindowWidth = 64;
        //コンソールウインドウの大きさ

        int screenWidth = Console.WindowWidth; 
        int screenHeight = Console.WindowHeight;
        //後で計算用に使う       

        int score = 0;
        //ゲームのスコア　初期値０

        int screenMiddle = screenWidth / 2;
        //画面中央位置　スネークの初期位置として使用

        int bodyLength = 3;
        //スネークの初期の体の長さ

        int food = 0;

        int user = 0;
        //ユーザーからの入力を受け取るための変数　後でユーザーの入力を格納する

        int top = 0;
        int left = 0;
        //スネークの頭の上と左の座標を示す変数宣言　

        string direction = "RIGHT";

        int sleep = 100;
        //ゲームの進行速度制御の値　初期値１００ミリ秒

        List<int> topbody = new List<int>();
        List<int> leftbody = new List<int>();
        //topbodyとleftbodyを宣言　スネークの体の位置を管理する

        topbody.Insert(0, 0);
        leftbody.Insert(0, screenMiddle);
        //スネークの体のfoodを食べたときの挿入される位置に使う

        food = 1;


        //コンソール画面の枠を■で並べて壁を作る
        for(int i = 0; i < screenWidth - 1; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("■");
        }

        for (int i = 0; i < screenWidth - 1; i++)
        {
            Console.SetCursorPosition(i, screenHeight - 1);
            Console.Write("■");
        }

        for (int i = 0; i < screenHeight - 1; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("■");
        }

        for (int i = 0; i < screenHeight - 1; i++)
        {
            Console.SetCursorPosition(screenWidth - 1, i);
            Console.Write("■");
        }


        Console.SetCursorPosition(screenWidth / 4, screenHeight / 2);
        Console.Write("Welcome to the Snake Game.");
        Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
        Console.Write("Use the arrow keys to collect the food.");
        Console.SetCursorPosition(screenWidth / 4, screenHeight / 2 + 3);
        Console.Write("Press any key to start.");
        //ゲームタイトルと説明等を表示

        Console.CursorVisible = false;
        //カーソル非表示
        Console.ReadKey();
        //ユーザーからの入力待機
        Console.CursorVisible = false;
        //入力があったら再度カーソルを非表示にする

        while (true)
        {
            bool hite = false;
            Console.Clear();

            //入力による進行方向の選択
            if (direction == "RIGHT") left++;

            else if (direction == "LEFT") left--;

            else if (direction == "DOWN") top++;

            else if (direction == "UP") top--;


            //ゲームの当たり判定
            if (top == screenHeight - 1) hite = true;

            if (top == 0) hite = true;

            if (left == screenWidth - 1) hite = true;

            if(left == 0) hite = true;


        }
    }
} 