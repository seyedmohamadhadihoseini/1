using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace _2
{

    public class Part8
    {
        public static void main()
        {
            //f1();
            //f2();
            // f3();
            // f4();
            //f5();
            //f6();
            //f7();
            //f8();
            f9();
        }
        static void f1()
        {
            System.Collections.ArrayList first = new ArrayList();
            first.Add("Hadi");
            first.Add(new Writer());
            first.Add(2.5);
            first.Add(new Company());
            first.RemoveAt(1);
            foreach (var x in first)
                Methods.print(x);
        }
        static void f2()
        {
            System.Collections.Stack stack = new Stack();
            stack.Push(1);
            stack.Push("Narges!");
            stack.Push('4');
            stack.Push(1.2);
            Methods.print(stack.Peek());
            int count = stack.Count;
            for (int i = 0; i < count; ++i)
                Methods.print(stack.Pop());
            Methods.print("Now the Size of Collection:" + stack.Count);

        }
        static void f3()
        {
            System.Collections.Specialized.StringCollection stringCollection = new System.Collections.Specialized.StringCollection();
            stringCollection.Add("hello");
            stringCollection.Add(" world!");
            string x = stringCollection[0];
            stringCollection[1] = "Narges";
            foreach (string item in stringCollection)
                Methods.print(item, false);
        }
        static void f4()
        {
            PersonCollection person = new PersonCollection();
            person.add(new Person
            {
                age = 20,
                EyeColor = MyColor.Black,
                name = "Hadi"
            });
            person.add(new Person
            {
                age = 20,
                EyeColor = (MyColor)Enum.Parse(typeof(MyColor), "Brown")
                ,
                name = "Narges"
            });
            foreach (Person item in person)
                Methods.print(item);
        }
        enum MyColor { Brown, Blue, Black, White, Yellow, Green }
        class Person
        {
            public string name { get; set; }
            public int age { get; set; }
            public MyColor EyeColor { get; set; }
            public override string ToString()
            {
                return $"Name:{name}  age:{age}  EyeColor:{EyeColor}";
            }
        }
        class PersonCollection : IEnumerable
        {
            System.Collections.ArrayList list = new ArrayList();

            public IEnumerator GetEnumerator()
            {
                foreach (Person item in list)
                {
                    yield return item;
                }
            }

            public void add(Person person)
            {
                list.Add(person);
            }
            public void Removeat(int index)
            {
                list.RemoveAt(index);
            }
        }
        static void f5()
        {
            System.Collections.Generic.Stack<string> st = new Stack<string>();
            st.Push("I");
            st.Push("Love");
            st.Push("You");
            st.Push("Narges");
            st.Reverse();
            while (st.Count != 0)
                Methods.print(st.Pop(), false);
            System.Collections.Generic.Queue<int> qt = new Queue<int>(1);
            qt.Enqueue(2);
            qt.Enqueue(4);
            //   qt.Reverse();
            Console.WriteLine();
            foreach (int item in qt)
                Methods.print(item);
            Console.WriteLine();
            Methods.print(qt.Peek());
            Methods.print(qt.Dequeue());
            Methods.print(qt.Dequeue());
        }
        static void f6()
        {
            System.Collections.Generic.Dictionary<string, double> pairs = new Dictionary<string, double>();
            pairs.Add("Narges", 20);
            pairs.Add("Mohamad Hadi", 20);
            pairs.Add("Hosein", 17);
            pairs.Add("Ali", 14);
            pairs["Reza"] = 23;
            KeyValuePair<string, double> keyValue = new KeyValuePair<string, double>("ahmad yoosofan", 45);
            pairs.Append(keyValue);
            foreach (var x in pairs)
                Methods.print(x);
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>()
            {
                ["Zahra"] = 20,
                ["Mohamad"] = 19,
                ["Narges"] = 19
            };
            Console.WriteLine();
            foreach (KeyValuePair<string, int> x in keyValuePairs)
            {
                Methods.print(x);
            }
        }
        static void f7()
        {
            System.Collections.Generic.List<Person> people = new List<Person>()
        {
            new Person()
            {
                name="Narges",age=20,EyeColor=(MyColor)Enum.Parse(typeof(MyColor),"Brown")
            },
            new Person{name="Mohamd Hadi",age=19,EyeColor=MyColor.Black},
            new Person{name="Zahra",age=22,EyeColor=MyColor.Brown}
        };
            for (int i = 0; i < people.Count; ++i)
            {
                Methods.print(people[i]);
            }
        }
        static void f8()
        {
            System.Collections.Generic.SortedSet<double> numbers = new SortedSet<double>(new DoubleComparer())
        {
            1,5,7,2.5,78.6,-.12,14
        };
            foreach (double x in numbers)
                Methods.print(x);
            Console.WriteLine();
            System.Collections.Generic.SortedSet<string> MyStr = new SortedSet<string>(new StringComparer());
            MyStr.Add("Naregs Mohamadi");
            MyStr.Add("Hadi Hoseini");
            MyStr.Add("I Love You Narges!");
            MyStr.Add("zahra mohamadi");
            foreach (string x in MyStr)
                Methods.print(x);
            Console.WriteLine();
            System.Collections.Generic.SortedSet<Worker> workers = new SortedSet<Worker>()
        {
            new Worker{age=24,EyeColor=MyColor.Blue,name="hasan",Salary=200000,hourWork=5},
            new Worker{age=45,EyeColor=MyColor.Blue,name="Hosein",Salary=2000000,hourWork=15},
            new Worker{age=65,EyeColor=MyColor.Yellow,name="Mohamad",Salary=20000,hourWork=1},
            new Worker{age=20,EyeColor=MyColor.Brown,name="hadi",Salary=4000000,hourWork=10}

        };
            foreach (Worker worker in workers)
                Methods.print(worker);
        }
        class StringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(x, y);
            }
        }
        class DoubleComparer : IComparer<double>
        {
            public int Compare(double x, double y)
            {
                double resault = x - y;
                switch (resault > 0)
                {
                    case true:
                        return 1;
                    default:
                        if (resault == 0)
                            return 0;
                        else
                            return -1;
                }
            }
        }
        class Worker : Person, IComparable<Worker>
        {
            public float Salary { get; set; }
            public int hourWork { get; set; }
            public float TaxesWorker
            {
                get
                {
                    return Taxes();
                }
            }

            public int CompareTo(Worker other)
            {
                if (this.Salary > other.Salary)
                    return 1;
                else if (this.Salary < other.Salary)
                    return -1;
                else
                    return 0;

            }

            float Taxes()
            {
                return Salary * (float)0.1;
            }
            public override string ToString()
            {
                return base.ToString() + $"\tSalary:{Salary}   HourWork:{hourWork}-->Taxes={Taxes()}";
            }
        }
        static void f9()
        {
            System.Collections.ObjectModel.ObservableCollection<int> eventInt = new System.Collections.ObjectModel.ObservableCollection<int>() { 2, 3 };
            eventInt.CollectionChanged += EventInt_CollectionChanged;
            eventInt.Add(77);
            eventInt.Add(88);
            eventInt.RemoveAt(0);
           
        }



        private static void EventInt_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Methods.print("I love You Narges!");
            Methods.print($"Sender is {sender}");
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Methods.print("Add To Collection!\n");

                foreach (int x in e.NewItems)
                {
                    Methods.print(x);
                }
            }

        }
    }
}
