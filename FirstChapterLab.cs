using System;

namespace FirstChapterLab
{
    class MainClass
    {
        static Int64 Factorial(int x)
        {
            Int64 z = 1;
            for (int i = 1; i <= x; i++)
                z *= i;
            return z;
        }
        public static void Main(string[] args)
        {
            Console.Write("Enter your value: ");
            string arg=Console.ReadLine();
            Int64 result = Factorial(int.Parse(arg));
            Console.Write("Your factorial is: ");
            Console.WriteLine(result);
            Console.Beep(3000,3);
            Console.ReadLine();
        }
    }
}
