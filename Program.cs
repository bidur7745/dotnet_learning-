using System;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)

        {
            int a = 12;
            int b= 13;
            int c= 14;
            Console.WriteLine("Hello World");
            Console.WriteLine($"The sum of a, b and c is {a+b+c}");
            if( (a > b) && (a > c))
            {
                Console.WriteLine("a is the highest");
            }
            else if((b > a) && (b > c))
            {
                Console.WriteLine("b is the highest");
            }
            else
            {
                Console.WriteLine("c is the highest");
             }
                Console.ReadLine();
        }
    }
}