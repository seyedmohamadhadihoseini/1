using System;

namespace _2
{
    class Program
    {
        static int Main(string[] args)
        {

            ///part 3
            /* Console.BackgroundColor = ConsoleColor.Green;
             Console.ForegroundColor = ConsoleColor.DarkBlue;
             Console.WindowHeight = 30;
             if (Console.CapsLock)
                 Console.Beep();
             Console.WindowTop = 100;
             Console.Clear();
             Console.WriteLine($"Hello Dear {args[0] + " " + args[1]}");
             var drives = Environment.GetLogicalDrives();
             Console.WriteLine(Environment.CurrentDirectory);
             foreach (var x in drives)
             {
                 Console.WriteLine(x);
             }
             Console.WriteLine("I Love You Seyed!\n");
             Console.WriteLine(Environment.OSVersion);
             Console.WriteLine(Environment.ProcessorCount);
             Console.WriteLine(Environment.Is64BitProcess);
             Console.WriteLine(Environment.MachineName);
             Console.WriteLine(Environment.SystemDirectory);
             Console.WriteLine(Environment.UserName);
             Console.WriteLine("{0:e0}", 0.0016);
             int zx = 25;
             string Seyed = "Seyed";
             string xn = $"You Are In My Heart For Ever {Seyed}! {zx}";
             Console.WriteLine(xn);
             Console.ReadKey();
             Console.Beep(700, 2000);
             Console.BackgroundColor = ConsoleColor.Black;
             Console.ForegroundColor = ConsoleColor.White;
             Console.Clear();
             string Bye = string.Format("This is the end of application! {0:X}", 1445545);
             Console.WriteLine(Bye);
             Console.ReadKey();*/



            ///part4
            /* int g = new int();
             System.SByte x = 4;

             Console.WriteLine(g);
             person a = new person();
             a.family = "hoseini";
             a.name = "hadi";
             person b = new person();
             b.family = "hoseini";
             b.name = "hadi";
             Console.WriteLine(object.ReferenceEquals(a, b));
             object dd = "hadi";
             Console.WriteLine(dd.GetHashCode());

             Console.WriteLine(System.Int32.MaxValue);
             Console.WriteLine(System.Int32.MinValue);
             int i = 2147483647;
             int j = 2147483647;
             i++;
             //for (i = 2142254147; i - j == 1; i++, j++) ;
             Console.WriteLine(i - j);
             Console.WriteLine(Convert.ToInt32('0'));
             DateTime date = new DateTime(2022, 02, 14, 18, 5, 14);
             System.Globalization.PersianCalendar persian = new System.Globalization.PersianCalendar();
             Console.WriteLine(date.ToString("hh:mm:ss     yyyy/MM/dd"));//formatting!! its very fun
             string test;
             print("Enter a String:");
             test = Console.ReadLine();
             int sym = 0, digit = 0, lether = 0;
             foreach (var element in test)
             {
                 if (char.IsDigit(element))
                     digit++;
                 else if (char.IsLetter(element))
                     lether++;
                 else if (char.IsSymbol(element))
                     sym++;
             }
             print($"number of digit:{digit} and length of letter:{lether} lenSym:{sym}\n");




             print("Enter first num:");
             System.Numerics.BigInteger first, second;
             first=System.Numerics.BigInteger.Parse(Console.ReadLine());
             print("Enter Second num:");
             second = System.Numerics.BigInteger.Parse(Console.ReadLine());
             print($"multyply={first * second}  division:{first / second}  plus:{first + second} Minus:{first - second}\n");*/

            //PART5
            /*  string[] vs = { "Mohamadhadi", "Seyed", "Zahra", "hoseini", "mohamadi" };
              foreach (var x in vs)
                  print(x);`
              string h = string.Join(" ", vs, 1, 3);
              print(h);
              int po;
              CharEnumerator charEnumerator;
              charEnumerator = h.GetEnumerator();
              Console.WriteLine("Hello {0}", "Seyed");



              string mystr = "Seyed Mohamad Hadi Hoseini With her Wife Seyed Mohamadi!";
              string my = "   Seyed Mohamad Hadi   ";
              string x1 = "1";
              string x2 = "21";
              print(x1.CompareTo(x2));
              print(my.Trim('e'));
              print(mystr.Contains(my));
              print(mystr);
              print(my.Trim());///remove from up and down the space or custom characters
              print(mystr.Contains(my.Trim()));



              print(x2.EndsWith(x1));//this mean the end of x2 is x1
              print(mystr.StartsWith(my.Trim()));//this mean the start of mystr is my
              int count = x1.Length + 1;
              print("\n\n");
              for (int i = 0; i < count; ++i)
              {
                  x1 = x1.Replace(x1[i].ToString(), "I Love You Seyed!");
              }
              print(x1);

              x1 = "1111111";
              print(x1.Replace('1', '2'));//get some string or char to replaceAll old str or char


              var result = mystr.Split(' ');//to dispart a string to some string as array
              foreach (var item in result)
                  print(item);
              x1 = string.Join(" ", result);
              print(x1);


              print(mystr.IndexOf(my.Trim()));//return first index where my.trim() and mystr is matched;
              x1 = "abcdeaa";
              print(x1.LastIndexOf("a"));//return last index where my.trim() and mystr is matched;


              print(x1.ToUpper());//to upper all of character
              print(x1.ToUpper().LastIndexOf('D'));


              x1 = x1.Substring(2, 5);// to SubStr and dispart some of part of the string! the 5 is len and 2 is place start
              print(x1);

              

              //jagged array
              int[,] Mark = new int[2, 3];
              Mark[0, 1] = 0;
              print(Mark[0, 1]);
              char[][] val = new char[2][];
              for (int i = 0; i < 2; i++)
                  val[i] = new char[i + 5];
              val[1][5] = 'a';
              print(val[1][5]);


              int? tr = null;
              int? url = null;

              Country mycount = new Country("iRaN");
              print(mycount.Name);
              mycount.Unit = (unit)Enum.Parse(typeof(unit), "Rial");
              */
            /*  Country first = new Country("Iran")
              {
                  Unit = (unit)Enum.Parse(typeof(unit), "Rial")

              };*/



            //Start Part7
            //Methods.part_1();            //Methods.part_2();
            /* Writer first = new Writer
             {
                 name = "pencil",
                 price = 14000
                 ,company=new Company
                 {
                     Address="Kashan",id=20
                 }
             };
             Writer second = new Writer
             {
                 name = "pen",
                 price = 1000
                 ,company=new Company
                 { id=21,Address="Tehran"}
             };
             //second = first;//type1 copy
             second = (Writer)first.Clone();
             second.price = 58000;
             second.company.id = 14;

             Point[] point = new []{new Point(14,10),new Point(12,11) ,new Point(3,2),new Point(12,24),new Point(13,7)};
             Array.Sort(point);
             for (int i = 0; i < point.Length; i++)
                 point[i].print();

		
             //    Methods.part7_3();
             Methods.part7_4();*/






             Part8.main();
            //part9.main();
            //Part10.main();
            //part11.main();
            //Part12.main();
            Console.ReadKey();
            return 0;
        }
        static void Print<T>(T x)
        {
            Console.WriteLine(x);
        }
    }

}
