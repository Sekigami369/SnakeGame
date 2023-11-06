﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class Snake
{
    public static void Main(string[] args)
    {
        DateTime time = DateTime.Now;

        Random random  = new Random();
        
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
        
       
        int leftfood = 0;
        int topfood = 0;

        int user = 0;
        //ユーザーからの入力を受け取るための変数　後でユーザーの入力を格納する

        int top = screenHeight / 2;
        int left = screenMiddle;
        //スネークの頭の上と左の座標を示す変数宣言　

        string direction = "RIGHT";

        int sleep = 500;
        //ゲームの進行速度制御の値　初期値１００ミリ秒

        List<int> topbody = new List<int>();
        List<int> leftbody = new List<int>();
        List<string> food = new List<string>();
        //topbodyとleftbodyを宣言　スネークの体の位置を管理する


        //コンソール画面の枠を■で並べて壁を作る
       

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

        for (int i = 0; i < screenWidth - 1; i++)
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


        while (true)
        {
            Console.Clear();
            bool hit = false;

           
            //入力による進行方向の選択
            if (direction == "RIGHT") left++;

            else if (direction == "LEFT") left--;

            else if (direction == "DOWN") top++;

            else if (direction == "UP") top--;




            //キーイベントが発生するまでfalseなのでキー入力に依存しなくて
            //スネークが動き続ける
            if (Console.KeyAvailable)
            {
                //方向キーを指定
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.RightArrow && direction != "LEFT")
                {
                    direction = "RIGHT";
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow && direction != "RIGHT")
                {
                    direction = "LEFT";
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow && direction != "DOWN")
                {
                    direction = "UP";
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && direction != "UP")
                {
                    direction = "DOWN";
                }
            }
            
            //ゲームの当たり判定
            if (top == screenHeight - 1) hit = true;

            if (top == 0) hit = true;

            if (left == screenWidth - 1) hit = true;

            if(left == 0) hit = true;


            //スネークの頭が壁もしくは自分と座標が重なったらあたり判定
            for(int f = 0; f < topbody.Count; f++)
            {
                if(top == topbody[f] && left == leftbody[f]) hit = true;
            }


            if (hit)
            {
                Console.Clear();
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 - 1);
                Console.Write("Game over");
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
                Console.Write("Press enter to exit the game");
                string SaveScore = "score: " + score;
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
                Console.Write(SaveScore);
                string usetime = "Survival Time: " + time.Minute + ":" + time.Second;
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);
                Console.Write(usetime);

                Console.WriteLine(usetime);
                Console.ReadKey();

                //リスタート処理をここに書く
            }

            string removeFood = "●";
            if (top == topfood && left == leftfood)
            {
                food.Clear();
                score++;
                bodyLength++;
            }



            //ランダムな位置にfoodを表示させる
            if (!food.Contains(removeFood))
            {
               
                food.Insert(0,"●");
                leftfood = random.Next(1,  screenHeight - 2);
                topfood = random.Next(1, screenWidth - 2);              
               
            }
            Console.SetCursorPosition(topfood, leftfood);
            Console.Write(food[0]);

            time = DateTime.Now;
            Console.SetCursorPosition(2, 0);
            Console.Write("score: " + score);
            Console.SetCursorPosition(2, 1);
            Console.Write("Survival Time: " + time.Minute + ":" + time.Second);



            //スネークの体作る
            for(int i = 0; i < topbody.Count; i++)
            {
                Console.SetCursorPosition(leftbody[i], topbody[i]);
                Console.Write("■");
            }


            //移動を表現するために先頭に新しい体を追加
            //追加して長くなった分末尾を削除することで前に進む
            leftbody.Insert(0, left);
            topbody.Insert(0, top);
            if (topbody.Count > bodyLength)
            {
                leftbody.RemoveAt(leftbody.Count - 1);
                topbody.RemoveAt(topbody.Count - 1);

            }
            Thread.Sleep(sleep);
        }
    }
}
//スネークの体が進むと増え続ける
//当たり判定がおかしい
//スネークが自動ですすまない
//foodが新たに出現していない
