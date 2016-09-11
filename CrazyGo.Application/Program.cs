using CrazyGo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s1 = "hello";
            //string s2 = "iello";
            //s2 = s2.Replace('i', 'h');
            //Console.WriteLine("s1 = " + s1);
            //Console.WriteLine("s2 = " + s2);
            //Console.WriteLine("ReferenceEquals : " + Object.ReferenceEquals(s1, s2));
            //Console.WriteLine("Equals : " + s1.Equals(s2));
            //Console.WriteLine("Operator == : " + (s1 == s2));

            //Console.WriteLine();

            //var h1 = new HashSet<string>();
            //h1.Add(s1);
            //var h2 = new HashSet<string>();
            //h2.Add(s2);
            //Console.WriteLine("SetEquals : " + h1.SetEquals(h2));


            Stone s = null;
            Console.WriteLine(s.Player);

        }

        private static void TestMergeGroup()
        {
            Player player = new HumanPlayer();
            Group group1 = new Group(new Stone(new Position(3, 5), player));
            Group group2 = new Group(new Stone(new Position(4, 5), player));
            Stone stone = new Stone(new Position(3, 4), player);
            group1 += stone;
            group1 += group2;
            foreach (var p in group1.AdjacentPositions)
                Console.WriteLine(p);
        }
    }
}
