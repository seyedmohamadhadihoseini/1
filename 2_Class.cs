using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace _2
{
    /*
    public enum unit : int
    {
        Dollar,
        Rial, Euro, Afghan, Dinar
    }
    class Country
    {
        public readonly string Name;
        public unit Unit { get; set; }
        public Country(string Name)
        {
            Name = Name.Substring(0, 1).ToUpper() + Name.Substring(1).ToLower();
            this.Name = Name;
        }
        class City
        {
            public string message { get; set; }
            public readonly String Name;
            public City(string Name) { this.Name = Name; }
            public int population { get; set; }
            public float Squra { get; set; }
            public int id { get; set; }
        }
        class CityCenter : City
        {
            int[] city;
            public CityCenter(string Name) : base(Name)
            {
                city = new int[len];
            }
            public int len { get; set; } = 0;
            public int[] cityId { get; set; }
        }
    }
    class animal
    {
        public string id { get; set; }
        animal()
        {
            id = "0";
        }


        ~animal()
        {
            Console.WriteLine("Hooy!!\n");

        }
    }
    class person
    {
        public string name { get; set; }
        public string family { get; set; }
    }*/

}
//part7
class MyException : ApplicationException
{
    public MyException() : base()
    {

    }
    public MyException(string s, Exception ex) : base(s, ex)
    {

    }
    public MyException(string s) : base(s) { }
}
static class Methods
{
    public static void part7_1()
    {
        throw new MyException();
    }
    public static void part7_2()
    {
        MyException x = new MyException("NotNegative!", new OverflowException());
        throw x;
    }
    public static void part7_3()
    {
        System.Collections.BitArray bit = new BitArray(8);
        bit.SetAll(true);
        bit.Set(0, false);
        bit.Set(7, false);
        BitArray bit1 = new BitArray(8);
        bit1.SetAll(false);
        bit1.Set(3, true);
        bit1.Set(0, true);
        printBits(bit1);
        printBits(bit);
        printBits(bit);
        bit.Or(bit1);
        bit.And(bit1);
        printBits(bit);
        bit.Or(new BitArray(new[]{false, true,true,true,false,true,true,true}));
        printBits(bit);
    }
    static void printBits(System.Collections.BitArray bit)
    {
        foreach (bool x in bit)
        {
            Console.Write(x ? 1 : 0);
        }
        Console.WriteLine();
    }
}
class Writer : System.ICloneable
{
    public int price { get; set; }
    public string name;
    public Company company { get; set; }

    public object Clone()
    {
        return new Writer
        {
            name = this.name,
            price = this.price
            ,
            company = new Company
            {
                Address = this.company.Address,
                id = this.company.id
            }
        };
    }
    public Writer ShaddowCopy()
    {
        return this.MemberwiseClone() as Writer;
    }
}
class Company
{
    public string Address { get; set; }
    public int id { get; set; }
}
class Point : System.IComparable
{
    int x { get; set; } = 0;
    int y { get; set; } = 0;
    public Point(int x = 0, int y = 0)
    {
        this.x = x;
        this.y = y;
    }
    int getX() { return x; }
    int getY() { return y; }
    public void print() { Console.WriteLine("(" + x + "," + y + ")"); }

    public int CompareTo(object obj)
    {
        var temp = obj as Point;
        return (this.getX() - temp.getX() != 0) ? this.getX() - temp.getX() : (this.getY() - temp.getY());
    }
}


