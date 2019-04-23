using System;

namespace C___Coloring_Colorfully
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = Console.ReadLine();
            int N = S.Length;

            string str01 = Make01(false,N);
            string str10 = Make01(true,N);

            Console.WriteLine(Math.Min(diffCount(S,str01,N),diffCount(S,str10,N)));
        }

        // 0と1を交互に繰り返す文字列を生成
        static string Make01(bool isStart1,int count)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for(int i = 0 ; i < count ; i++)
            {
                sb.Append(isStart1?"1":"0");
                isStart1 = !isStart1;
            }
            return sb.ToString();
        }

        // 文字列を比較し、違う文字の数を返す
        static int diffCount(string str1,string str2,int count)
        {
            int _diffCount = 0;
            for(int i = 0 ; i < count ; i++)
            {
                if(str1[i] != str2[i]) _diffCount++;
            }

            return _diffCount;
        }
    }
}
