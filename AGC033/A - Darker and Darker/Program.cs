using System;
using System.Collections.Generic;
using System.Linq;


namespace A___Darker_and_Darker
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Console.ReadLine().Split(' ');
            var H = int.Parse(read[0]);
            var W = int.Parse(read[1]);

            //マス目の配置を読み込む
            var map = new string[H];
            for(int i = 0 ; i < H ; i++) map[i] = Console.ReadLine();

            //何回目の操作で黒になるかを記録する配列を作成
            var steps = new int[H,W];
            for(int i = 0 ; i < H ; i++) for(int j = 0 ; j < W ; j++) steps[i,j] = int.MaxValue;

            //黒マスの位置をチェックし、処理用キューに格納する
            var checkGrids = new Queue<Grid>();
            for(int i = 0 ; i < H ; i++)
            {
                for(int j = 0 ; j < W ; j++)
                {
                    if(map[i][j] == '#')
                    {
                        checkGrids.Enqueue(new Grid(i,j));
                        steps[i,j] = 0;
                    }
                }
            } 

            //キューが空になる=白マスがなくなるまで操作を繰り返す
            while(checkGrids.Count != 0)
            {
                var grid = checkGrids.Dequeue();
                var h = grid.x;
                var w = grid.y;
                var step = steps[h,w];

                //上
                if(h > 0 && step + 1 < steps[h-1,w])
                {
                    steps[h-1,w] = step + 1;
                    checkGrids.Enqueue(new Grid(h-1,w));
                }
                //下
                if(h < H-1 && step + 1 < steps[h+1,w])
                {
                    steps[h+1,w] = step + 1;
                    checkGrids.Enqueue(new Grid(h+1,w));
                }
                //左
                if(w > 0 && step + 1 < steps[h,w-1])
                {
                    steps[h,w-1] = step + 1;
                    checkGrids.Enqueue(new Grid(h,w-1));
                }
                //右
                if(w < W-1 && step + 1 < steps[h,w+1])
                {
                    steps[h,w+1] = step + 1;
                    checkGrids.Enqueue(new Grid(h,w+1));
                }
            }

            Console.WriteLine(steps.Cast<int>().Max());
        }
    }
    class Grid
    {  
        public int x{get;}
        public int y{get;}

        public Grid(int _x,int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
