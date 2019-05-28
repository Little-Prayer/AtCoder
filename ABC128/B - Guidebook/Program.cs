using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace B___Guidebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var restaulants = new restaulant[N];
            for(int i = 0 ; i < N ; i++)
            {
                var read = Console.ReadLine().Split(' ');
                restaulants[i] = new restaulant();
                restaulants[i].number = i + 1;
                restaulants[i].city = read[0];
                restaulants[i].point = int.Parse(read[1]);
            }
            restaulants = restaulants.OrderBy(r => r.city).ThenByDescending(r => r.point).ToArray();

            for(int i = 0 ; i < N ; i++) Console.WriteLine(restaulants[i].number);
        }
    }

    struct restaulant
    {
        public int number{get;set;}
        public string city{get;set;}
        public int point{get;set;}
    }
}
