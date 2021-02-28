using System;

namespace RootOfEquation
{
    class Program
    {
        static double CalculateFunction(double x)
        {
            return Math.Pow(x, 4) - 3 * Math.Pow(x, 2) + 75 * x - 10000;
        }

        static double CalculateFirstDerivative(double x)
        {
            return 4 * Math.Pow(x, 3) - 6 * x + 75;
        }

        static double CalculateSecondOrderDerivative(double x)
        {
            return 12 * Math.Pow(x, 2) - 6;
        }

        static void Main()
        {
            Console.Write("Введите a, b и точность через пробелы: ");
            string[] input = Console.ReadLine().Split();

            double a = Convert.ToDouble(input[0]);
            double b = Convert.ToDouble(input[1]);
            double precision = Convert.ToDouble(input[2]);

            double prevResult = Int32.MaxValue;
            double result = (CalculateFunction(a) * CalculateSecondOrderDerivative(a) > 0) ? a : b;
            
            while (Math.Abs(result - prevResult) > precision)
            {
                prevResult = result;
                result -= CalculateFunction(result) / CalculateFirstDerivative(result);
            }

            Console.WriteLine($"Результат: {result}");
        }
    }
}
