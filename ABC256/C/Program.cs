using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var hw = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var h1 = hw[0];var h2 = hw[1];var h3=hw[2];var w1=hw[3];var w2 = hw[4];var w3 = hw[5];

            var result = 0;
            for (int a11=1;a11<=30;a11++)
            {
                for(int a12=1;a12<=30;a12++)
                {
                    for(int a21=1;a21<=30;a21++)
                    {
                        for(int a22=1;a22<=30;a22++)
                        {
                            if(a11+a12>=h1)break;
                            if(a11+a21>=w1)break;
                            if(a21+a22>=h2)break;
                            if(a12+a22>=w2)break;
                            var a13 = h1-a11-a12;
                            var a23 = h2-a21-a22;
                            var a31 = w1-a11-a21;
                            var a32 = w2-a12-a22;
                            if(w3-a13-a23==h3-a31-a32&&w3-a13-a23>0)result++;
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
