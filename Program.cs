using System;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Learning Switch case in C sharp ");
            int x, y;
            Console.WriteLine("Enter two Integer");
            x = int.Parse(Console.ReadLine());
            y = int.Parse(Console.ReadLine());
            Console.WriteLine("Operation");
            Console.WriteLine("1 = Addition\n2 = Subtraction\n3 = Multiplication");
            Console.WriteLine("operation");
            Console.WriteLine("Enter your operation ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.WriteLine($"The addtion of x and y is {x + y}");
                    break;
                case 2: Console.WriteLine($"The subtraction of x from y is {x - y}");
                    break;
                case 3: Console.WriteLine($"The muntiplication of  x and y is {x * y}");
                    break;
                default: Console.WriteLine(" wrong choice");
                    break;
            }

            Console.WriteLine("\nLearning for loop in C programming ");

            int a;
            for (a=0; a<10; a++)
            {
                Console.WriteLine(a);
            }


        }
    }
}