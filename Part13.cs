using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Part13
    {
        public static void main()
        {
            //f1();
            //f2();
            //f3();
            //f4();
            //f5();
            //f6();
            //f7();
            f7();
        }
        static void f1()
        {
            Console.WriteLine($"Max generation is:{System.GC.MaxGeneration}+1");
            Console.WriteLine($"total Memory:{GC.GetTotalMemory(false)}");
            Console.WriteLine($"total Memory(method wait for garbage collector):{GC.GetTotalMemory(true)}");
        }
        static void f2()
        {
            Person person1 = new Person() { id = 0, name = "hadi" };
            Person person2 = new Person() { id = 1, name = "ahmad" };
            Console.WriteLine($"Generation of person1(hadi):{GC.GetGeneration(person1)}");
            Console.WriteLine($"Generation of person2(ahmad):{GC.GetGeneration(person2)}");
            Person[] people = new Person[400000];
            Console.WriteLine($"Generation of people(ahmad):{GC.GetGeneration(people)}");
            GC.Collect(2,GCCollectionMode.Forced);
            Console.WriteLine($"garbage collector for generation '0'  {GC.CollectionCount(0)} was called");
            Console.WriteLine($"garbage collector for generation '1,0'  {GC.CollectionCount(1)} was called");
            Console.WriteLine($"garbage collector for generation '2,1,0'  {GC.CollectionCount(2)} was called");
        }
        class Person
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        static void f3()
        {
            Student student = new Student { name = "Narges", numberId = 79, reshte = "Mama" };
        }
        class Student
        {
            ~Student()
            {
                Console.Beep();
                Console.WriteLine("Constractor of this Student were called!");
                Console.ReadKey();
            }
            public int numberId { get; set; }
            public string name { get; set; }
            public string reshte { get; set; }
        }
        static void f4()
        {
            Student student = new Student { name = "Narges", numberId = 79, reshte = "Mama" };
            int numberOfGenerationBeforeNulling = GC.GetGeneration(student);
            student = null;
            GC.Collect(numberOfGenerationBeforeNulling);
            GC.WaitForPendingFinalizers();
        }
        static void f5()
        {
            using (Teacher teacher = new Teacher() { id = 14, name = "Ahmad", Salary = 14000000 })
            {
                Console.WriteLine($"Name:{teacher.name}   id:{teacher.id}   Salary:{teacher.Salary}");
            }
            Console.WriteLine("All thing Done And f5() Finished!");
        }
        class Teacher : Person, IDisposable
        {
            ~Teacher()
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Constractor were Called");
                Console.ReadKey();
            }
            public int Salary { get; set; }
            public void Dispose()
            {
                Console.WriteLine("Object Were Killed!");
                Console.WriteLine("Dispose method automaticly Run!");
                //GC.SuppressFinalize(this); //to dont run ~Teacher()
            }
        }
        static void f6()
        {
            using (Worker worker = new Worker { id = 27, name = "Soltan", WorkerHour = 8 })
            {

            }
            Console.Write("\nfor Woker2:");
            Worker worker1 = new Worker { name = "ali", WorkerHour = 20, id = 788 };
        }
        class Worker : Person, IDisposable
        {
            bool disposed = false;//one of ~worker  Dispose Run
            ~Worker()
            {
                Console.WriteLine("Distructor of Worker is Calling!");
                CleanUp(false);
            }
            public void Dispose()
            {
                CleanUp(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void CleanUp(bool disposing/*to findout who run this method(Dispode or ~Worker)*/)
            {
                if (!disposed)
                {
                    disposed = true;
                    if (disposing)
                    {
                        //Clean Up Manage Resoureses

                    }
                    //clean up UnManaged Resources
                    Console.WriteLine(((disposing) ? "Dispose()" : "~Worker()") + "is Runing");
                    if (!disposing)
                        Console.ReadKey();
                }
            }
            public int WorkerHour { get; set; }
        }
        static void f7()
        {
            Lazy<Tree> tree = new Lazy<Tree>(()=>new Tree {name="Orange",age=14 });
            Console.WriteLine("is Lazy of Tree Were Used?   {0}", tree.IsValueCreated);
            Console.WriteLine(tree);
            Console.WriteLine(tree.Value);
            Console.WriteLine(tree);
            Lazy<Tree> tree1 = new Lazy<Tree>(() => new Tree ( age : 27, name : "Banana" ));
            Console.WriteLine("\n\n****************************************");
            Console.WriteLine("Now tree1 was Selected!");
            Console.WriteLine(tree1);
            Console.WriteLine(tree1.Value);
            Console.WriteLine(tree1);
        }
        class Tree
        {
           public Tree()
            {
                Console.WriteLine("a Tree Without any Information Created!");
            }
            public Tree(string name,int age)
            {
                this.age = age;
                this.name = name;
                Console.WriteLine("welcome new Tree=> Name:{0}  Age:{1}", this.name, this.age);
            }
            public string name { get; set; }
            public int age { get; set; }
            public override string ToString()
            {
                return $"({name},{age})";
            }
        }
    }
}
