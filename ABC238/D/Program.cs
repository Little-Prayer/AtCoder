using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                var aS = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                if (aS[0] > aS[1])
                {
                    Console.WriteLine("No");
                    continue;
                }
                var stra = Convert.ToString(aS[0], 2).ToCharArray();
                var strS = Convert.ToString(aS[1], 2).ToCharArray();
                Array.Reverse(stra);
                Array.Reverse(strS);
                var isCarrying = false;
                var flag = true;
                for (int d = 0; d < stra.Length; d++)
                {
                    if (isCarrying)
                    {
                        if (stra[d] == '1')
                        {
                            if (strS[d] == '1')
                            {
                                isCarrying = true;
                            }
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                        else
                        {
                            if (strS[d] == '1')
                            {

                            }
                            else
                            {

                            }

                        }
                    }
                    else
                    {
                        if (stra[d] == '1')
                        {
                            if (strS[d] == '1')
                            {
                                flag = false;
                                break;
                            }
                            else
                            {
                                isCarrying = true;
                            }
                        }
                        else
                        {
                            if (strS[d] == '1')
                            {

                            }
                            else
                            {

                            }

                        }
                    }
                }
            }
        }
    }

}
