

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    static class Int32Extention
    {
        public static double Plus(this double me, double you)
        {
            return me + you;
        }

    }
    static class AllThing
    {
        public static void show<T>(this T parameter)
        {
            Console.WriteLine(parameter);
        }
    }
    static class ComputerExtention
    {
        public static void show(this part11.Computer computer)
        {
            Console.WriteLine($"{computer.company}  {computer.name}   {computer.Price}$  ");
        }
    }
    class part11
    {
        public static void main()
        {
            //f1();
            //f2();
            //f3();
            //f4();
            //f5_typeWithOutName();
            //f6();
            //f7();
            //f8();
            f9();
        }
        static void f1()
        {
            Person person = new Student();
            //false
            //Student student = f1A();
            Student student = (Student)person;
        }
        class Person { }
        class Student : Person { }
        static void f2()
        {
            IMyCollection<Student> student = new CollectionOfPerson<Student>();
            IMyCollection<Person> person = student;
        }
        interface IMyCollection<out T>
        {
            ///Error
            // T this[int index] { get;set; };
            T this[int index] { get; }
            int count { get; }
        }
        class CollectionOfPerson<T> : IMyCollection<T> where T : Person
        {
            public T this[int index] => throw new NotImplementedException();

            public int count => throw new NotImplementedException();
        }
        static void f3()
        {
            EntityPerson<Person> person = new EntityPerson<Person>();
            IEntityProcessor<Student> student = person;
        }
        interface IEntityProcessor<in T>
        {
            ///Error
            //T this[int index] { get; }
            void Sum(T i);
        }
        class EntityPerson<T> : IEntityProcessor<T> where T : Person
        {
            public void Sum(T i)
            {
                throw new NotImplementedException();
            }
        }
        static void f4()
        {
            IEnumerable<string> son = new List<string>();
            IEnumerable<object> dad = son;

            Action<object> dad2 = p => Console.WriteLine(p);
            Action<string> son2 = dad2;
        }

        static void f5_typeWithOutName()
        {
            var Computer = new
            {
                price = 4,
                Name = "Asus"
            };
            Console.WriteLine($"{Computer.Name}  price:{Computer.price}");

        }
        static void f6()
        {
            double x = 5;
            x.Plus(6).Plus(10).show();//extention method


            Computer computer = new Computer(new Company { Address = "Kashan", Name = "Hadi", id = 14 });
            computer.show();
        }
        public class Computer
        {
            public Company company { get; }
            public Computer(Company x)
            {
                this.company = x;
            }
            public string name { get; set; } = "Asus";
            public int Price { get; set; } = 1000000;

        }
        static void f7()
        {
            int temp = 14;
            int[] temparray = new[] { 7, 5, 9, 2, 43, 4 };
            unsafe
            {
                int* x = &temp;
                *x = 10;
                Console.WriteLine(*x);
                Console.WriteLine();
                Console.WriteLine();
                fixed (int* point = &temparray[0])
                {
                    int* resualt = point;
                    for (int i = 0; i < temparray.Length; i++)
                        Console.WriteLine(resualt[i]);
                }
            };
        }
        static unsafe void f8()
        {
            int* point = stackalloc int[20];
            for (int i = 0; i < 20; i++)
                point[i] = i + 1;
            for (int i = 0; i < 20; ++i)
                Console.WriteLine(point[i]);
        }
        static unsafe void f9()
        {
            Node node = new Node();
            node.Value = 4;
            Node RigthNode = new Node();
            node.RigthValue = &RigthNode;
            node.RigthValue->Value = 4;
            Console.WriteLine(RigthNode.Value);

        }
        unsafe struct Node
        {
            public int Value { get; set; }
          public  Node* RigthValue { get; set; }
            public Node* LeftValue { get; set; }
        }
    }


}


