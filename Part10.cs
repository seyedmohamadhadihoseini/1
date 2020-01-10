using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{

    class Part10C
    {
        public delegate double MathOp(double n, double m);
        public static int main()
        {
            //f1();
            //f2();
            //f3();
            //f4();
            //f5();
            f6();
            return 0;
        }
        static void f1()
        {
            MathOp math = delegate (double n, double m)
              {
                  return m / n;
              };
            Console.WriteLine(math(8, 8));
        }
        static void f2()
        {
            f2A(delegate (double n, double m)
            {
                return n - m;
            });
        }
        static void f2A(MathOp math)
        {
            Console.WriteLine(math(8, 5));
        }
        static void f3()
        {
            MathOp math = (n, m) =>
              {
                  return m + n;
              };
            MathOp math1 = (n, m) => m * n;
            Console.WriteLine(math(7, 5));
            Console.WriteLine(math1(7, 5));

            hello h = () => Console.WriteLine("Hello World");
            h();
        }
        public delegate void hello();
        static void f4()
        {
            Action<int, string> action = (a, b) => Console.WriteLine(b+a);
            Func<string, int> strLen = str => str.Length;
            action(79, "Zahra Mohamadi ");
            Console.WriteLine(strLen("Narges"));
        }
        static void f5()
        {
            List<int> myList = new List<int>() { 1, 5, 9, 3, 4, 12 };
            List<int> myList2=myList.FindAll(element=>element<5);
            myList2.ForEach(p=>Console.WriteLine(p));
        }
        static void f6()
        {

            int[] arrray = new[] {7,5,2,16,4 };
            List<int> mylist = FindAll(arrray,t=>t<6);
            mylist.ForEach(p => Console.Write(p+"\t"));
        }
        public delegate bool test<T>(T obj);
        static List<T> FindAll<T>(IEnumerable<T>mylist,Predicate<T> predicate)
        {
            List<T> newlist = new List<T>();
            foreach (var item in mylist)
                if (predicate(item))
                    newlist.Add(item);
            return newlist;
            
        }
    }
}
