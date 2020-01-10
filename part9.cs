using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    public delegate void MathOp(int x, int y);
    class HelperForLearningDelegte
    {
        public static void Mainhelper()
        {
            MathOp math = part9.f1();
            math(2, 4);
        }
    }
    class part9
    {
        public static int main()
        {
            //HelperForLearningDelegte.Mainhelper();
            //f2();

            //f3(new MathOp(Sum));
            //f4();
            //f5();
            //f6();
            //f7();
            f8();
            return 0;
        }
        public static MathOp f1()
        {
            return Multy;
        }
        static void Multy(int x, int y)
        {
            Console.WriteLine($"{x}*{y}={x * y}");
        }
        static void f2()
        {
            MathOp math = new MathOp(Sum);
            math.Invoke(7, 5);
        }
        static void Sum(int x, int y)
        {
            Console.WriteLine($"{x}+{y}={x + y}");
        }
        static void f3(MathOp math)
        {
            for (int i = 0; i < 5; ++i)
                math(i, i + 5);
        }
        static void f4()
        {
            MathOp math = Sum;
            Console.Write("Time1:");
            math(4, 5);
            math += Multy;
            Console.Write("Time2:");
            math(4, 5);
            math -= Sum;
            Console.Write("Time3:");
            math(4, 5);
        }
        static void f5()
        {
            SomeWork<int> some = print<int>;
            some(1);
            SomeWork<string> work = show;
            work("Hello World!");
        }
        public delegate void SomeWork<T>(T param);
        static void print<T>(T input)
        {
            Console.WriteLine(input);
        }
        static void show(string s) { Console.WriteLine(s); }
        static void f6()
        {
            PersonRepoSitory personRepo = new PersonRepoSitory(NotificationForAdd);
            personRepo.add(new Person { age = 20, id = 79, Name = "MohamadHadi" });
            personRepo.RegisterAnotherNotification(NotficationAdd2);
            Console.WriteLine();
            personRepo.add(new Person { age = 17, id = 82, Name = "MohamadHosein" });
        }
        static void NotficationAdd2(Person person)
        {
            Console.WriteLine("Welcome To My Repository!");
        }
        static void NotificationForAdd(Person person)
        {
            Console.WriteLine($"{person.Name} with Id:{person.id}  and age:{person.age} were Added!");
        }
        class Person
        {
            public int age { get; set; }
            public string Name { get; set; }
            public int id { get; set; }
        }
        class PersonRepoSitory
        {
            public delegate void ONPersonChangedNotification(Person x);
            ONPersonChangedNotification onAdd;
            ONPersonChangedNotification onRemove;
            public PersonRepoSitory(ONPersonChangedNotification x)
            {
                onAdd += x;
            }
            public void RegisterAnotherNotification(ONPersonChangedNotification x)
            {
                onAdd += x;
            }
            public void UnRegisterForAdd(ONPersonChangedNotification x)
            {
                onAdd -= x;
            }
            public void add(Person person)
            {
                //add to dataBase
                onAdd(person);
            }
            public void Remove(Person x)
            {
                //Remove From database
                onRemove(x);
            }

        }

        static void f7()
        {
            PersonCollection collection = new PersonCollection();
            collection.OnForAdd += Collection_OnForAdd;
            collection.Add(new person { Address = "Jiroft", age = 19, name = "Seyed" });
            collection.Add(new person { Address = "Kashan", age = 19, name = "Mohamad Hadi" });
            Console.WriteLine();
            Console.WriteLine(collection);

            collection.AddNotification += RemoveNotification;
            collection.Remove(new person { Address = "Jiroft", age = 19, name = "Seyed" });
            Console.WriteLine();
            Console.WriteLine(collection);
        }
        static void RemoveNotification(person person)
        {
            Console.WriteLine($"{person.name} with age:{person.age}  Address:{person.Address} were remvoed!");
        }
        private static void Collection_OnForAdd(person person)
        {
            Console.WriteLine($"{person.name} with age:{person.age}  Address:{person.Address} were added!");
        }

        class person
        {
            public int age { get; set; }
            public string name { get; set; }
            public string Address { get; set; }

            public override string ToString()
            {
                return $"Name:{name}, Age:{age}, Address:{Address}\n";
            }


        }
        class PersonCollection
        {
            public OnAddNotification AddNotification = null;
            System.Collections.Generic.List<person> people = new List<person>();
            public delegate void OnAddNotification(person person);
            public event OnAddNotification OnForAdd;
            public void Add(person x)
            {
                people.Add(x);
                if (OnForAdd != null)
                    OnForAdd(x);
            }
            public void Remove(person x)
            {
                people.Remove(x);
                if (AddNotification != null)
                    AddNotification(x);
            }
            public override string ToString()
            {
                System.Text.StringBuilder stringBuilder = new StringBuilder();
                foreach (person item in people)
                    stringBuilder.Append(item.ToString());
                return stringBuilder.ToString();
            }

        }
        static void f8()
        {
            Func func = new Func();
            func.OnAdded += Func_OnAdded;
            func.Add(new Point { x_Side = 4, y_Side = 5 }, "I Love You Seyed!");
        }

        private static void Func_OnAdded(object sender, PointEventArgs e)
        {
            Console.WriteLine($"{e.myPoint }  with {e.Message} were Added");
        }

        class Point
        {
            public double x_Side { get; set; }
            public double y_Side { get; set; }
            public override string ToString()
            {
                return $"({x_Side},{y_Side})";
            }
        }
        class PointEventArgs:EventArgs
        {
            public PointEventArgs(Point point)
            {
                myPoint = point;
            }
            public Point myPoint { get; set; }
            public string Message { get; set; }
        }
        class Func
        {
            System.Collections.Generic.Dictionary<double, double> Mylist = new Dictionary<double, double>();
            public event EventHandler<PointEventArgs> OnAdded;
            public void Add(Point point,string Message)
            {
                Mylist.Add(point.x_Side,point.y_Side);
                OnAdded(this, new PointEventArgs(point) {Message=Message });
            }
            public void Remove(Point point)
            {
                Mylist.Remove(point.x_Side);
            }
        }
    }
}
