using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Part12
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
            //f8();
            //f9();
            f10();
        }
        static void printCollection<T>(IEnumerable<T> obj)
        {
            foreach (var item in obj)
                Console.WriteLine(item);
        }
        /// <summary>
        /// a query to select member from any type of collection with custom condition 
        /// and write numebr of new created collection!
        /// </summary>
        static void f1()
        {
            int[] number = new[] { 5, 6, 8, 2, 99, 55, 34 };
            var result = from item in number
                         where item > 8
                         select item;
            foreach (var item in result)
                Console.WriteLine(item);
            Console.WriteLine($"count is {result.Count()}");
            Console.WriteLine($"the count of number that bigger than 50:{result.Count(p => p > 50)}");
        }

        /// <summary>
        ///  Easy Sort 
        ///  Big to Low
        ///  Low To Big
        /// </summary>
        static void f2()
        {
            int[] number = new[] { 65, 47, 2, 35, 14 };
            var result1 = from parameter in number
                          orderby parameter ascending
                          select parameter;
            printCollection(result1);
            Console.WriteLine();
            var result2 = from p in number orderby p descending select p;
            printCollection(result2);
        }

        /// <summary>
        /// like f1 
        /// </summary>
        static void f3()
        {
            string[] name = new[] { "Mohamad", "Mahdi", "Ali", "Majid", "Javad" };
            var result = from p in name
                         where p.StartsWith("M")
                         select p;
            printCollection(result);
        }
        /// <summary>
        /// Functional Query Is UseFull Than Not Functional Qeury like f1,f2,f3() 
        /// </summary>
        static void f4()
        {
            string[] name = { "Ahmand", "Hadi", "Abdollah", "MohamadHadi", "Reza" };
            var result = name.Where(p => p.Length > 4).Select(p => p.ToLower());
            printCollection(result);
            Console.WriteLine();
            int[] number = { 44, 25, 14, 22, 36, 85, 2 };
            int count = 0;
            var resultnum = number.Where(p => p > 20).OrderBy(p => p).Select(p => $"Numebr{++count}:{p}").ToList();
            printCollection(resultnum);
        }
        static void f5()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Hadi", 79, 14));
            students.Add(new Student("Hosein", 82, 11));
            students.Add(new Student("Ali", 85, 7));
            students.Add(new Student("Ahmad", 90, 2));

            var result = students.Where(p => p.count < 11).OrderBy(p => p.count);
            foreach (var item in result)
                Console.WriteLine(item);
            Console.WriteLine();
            IEnumerable<string> result2 = students.Where(p => p.count > 10).OrderBy(p => p.count).Select(p => p.name);
            printCollection(result2);
        }
        class Student
        {
            public Student() { }
            public Student(string name, int id, int count)
            {
                this.name = name;
                this.id = id;
                this.count = count;
            }
            public int id { get; set; } = 0;
            public string name { get; set; }
            public int count { get; set; } = 1;
            public override string ToString()
            {
                return $"Name:{name}  Class:{count}  Id:{id}";
            }
        }

        static void f6()
        {
            List<int> myList = new List<int>()
            {
                25,14,32,2,78,24
            };
            Console.WriteLine("The Numbers is\n      ***********************     ");
            foreach (var item in myList)
            {
                Console.Write(item + "\t");

            }
            Console.WriteLine("\n\nAre All Number Lower Than 100?  " + (myList.All(p => p < 100) ? "Yes" : "No"));
            Console.WriteLine("Are Exist The 14 in numbers?   " + ((myList.Any(p => p == 14)) ? "Yes" : "No"));
            Console.WriteLine("Are Exist The 33 in numbers?   " + ((myList.Any(p => p == 33)) ? "Yes" : "No"));
            Console.WriteLine("Are Exist any  numbers?   " + ((myList.Any()) ? "Yes" : "No"));
        }
        static void f7()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("Python", "jadi.net", "Seyed"));
            books.Add(new Book("C#", "MicroSoft", "Hadi"));
            books.Add(new Book("c++", "Yoosofan", "Ahmad"));
            books.Add(new Book("Java", "Oracle", "MohamadHadi"));

            var result = books.Where((book, index) => index % 2 == 0).Select(book => new
            {
                id = book.publisher.Length,
                book.publisher,
                book.title,
                FullDetail = book.publisher + "    " + book.title,
                author = book.writer
            });
            Console.WriteLine("Publisher    Title     author");
            foreach (var item in result)
            {
                Console.WriteLine(item.FullDetail + "    " + item.author);
            }
        }
        class Book
        {
            public Book(string title, string publisher, string writer)
            {
                this.publisher = publisher;
                this.title = title;
                this.writer = writer;
            }
            public string title { get; set; }
            public string publisher { get; set; }
            public string writer { get; set; }
        }
        static void f8()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("Python", "Oracle", "Seyed"));
            books.Add(new Book("C#", "MicroSoft", "Hadi"));
            books.Add(new Book("c++", "MicroSoft", "Ahmad"));
            books.Add(new Book("Java", "Oracle", "MohamadHadi"));

            var result = books.GroupBy(p => p.publisher);
            foreach (var item in result)
            {
                Console.WriteLine("********************");
                Console.WriteLine("Publisher:{0}", item.Key);
                foreach (var member in item)
                    Console.WriteLine(member.title + "==>" + member.writer);
            }
        }
        static void f9()
        {
            List<Country> countries = new List<Country>()
            {
                new Country{id=98,Name="Iran",NumberinWorld=55},
                new Country{id=1,Name="United State",NumberinWorld=2},
                new Country{id=4,Name="Germany",NumberinWorld=3}
            };
            List<City> cities = new List<City>()
            {
                new City{Name="Tehran",CountryId=98,NumberInCountry=1},
                new City{Name="Kashan",CountryId=98,NumberInCountry=3},
                new City{Name="NewYork",CountryId=1,NumberInCountry=5},
                new City{Name="Munchen",CountryId=4,NumberInCountry=1}
            };
            var result = countries.Join(cities, myCountry => myCountry.id, city => city.CountryId, (myCountry, city) => new
            {
                id = myCountry.id + city.NumberInCountry,
                fullName = city.Name + "==>" + myCountry.Name,
                city.CountryId,
                ranking = city.NumberInCountry + myCountry.NumberinWorld
            }
            );
            foreach (var item in result)
                Console.WriteLine($"{item.fullName}:{item.CountryId}\tRanking:{item.ranking} " +
                    $"\tnew Id:{item.id}");
            {
                int result2 = result.Max(p => p.ranking);
                var result3 = result.Max(p => p.fullName);
                Console.WriteLine("Max Full Name :"+result3);
                Console.WriteLine("Max Ranking in cities:"+result2);
            }
        }
        class City
        {
            public string Name { get; set; }
            public int NumberInCountry { get; set; }
            public int CountryId { get; set; }
        }
        class Country
        {
            public int id { get; set; }
            public string Name { get; set; }
            public int NumberinWorld { get; set; }
        }
        static void f10()
        {
            int[] numbers = {25,34,14,23,72,2,16,34 };
            Console.WriteLine("The number");
            printCollection(numbers);
            Console.WriteLine("the First Number is:" + numbers.FirstOrDefault());
            Console.WriteLine("maximum is:"+numbers.Max());
            Console.WriteLine("minimum is:"+ numbers.Min());
            Console.WriteLine("Avarage is:" + numbers.Average());
            Console.WriteLine("Sum:" + numbers.Sum());
            Console.WriteLine("The last item :" + numbers.LastOrDefault());
            var reversed = numbers.Reverse();
            Console.WriteLine("The reverce are");
            foreach(int item in reversed)
            {
                Console.Write(item+"    ");
            }
            int[] num = { 7, 8, 7 };
            var result = num.Distinct();
            Console.WriteLine();
            Console.WriteLine("new list is");
            printCollection(result);

        }
    }
}
