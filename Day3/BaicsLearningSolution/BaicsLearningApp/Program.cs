using BaiscLearningApp;
using System;

namespace BasicLearningApp
{
    internal class Program
    {
        private void TakeTwoNumbersAndProcess()
        {
            int num1, num2;
            Console.WriteLine("Enter the first number");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            num2 = Convert.ToInt32(Console.ReadLine());
            FindGreatestOfTwoNumber(num1, num2);
        }
        private void FindGreatestOfTwoNumber(int num1, int num2)
        {
            if (num1 == num2)
                Console.WriteLine($"The numbers {num1} and {num2} are equal");
            else if (num1 > num2)
                Console.WriteLine($"The number {num1} is greater than {num2}");
            else
                Console.WriteLine($"The number {num2} is greater than {num1}");
        }
        static void Main(string[] args)
        {
            //Program program = new Program();
            //program.TakeTwoNumbersAndProcess();
            Login login = new Login();
            login.DoLogin();

        }
    }
    class Something
    {
        public void DoSomething()
        {
            Console.WriteLine("Doing something");
        }

    }
}