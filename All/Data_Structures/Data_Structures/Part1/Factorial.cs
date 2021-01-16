namespace Data_Structures.Part1
{
    public class Factorial
    {
        //4 = 4 * 3 * 2 * 1  
        //3 = 3 * 2 * 1
        public int CalculateFactorial(int value)
        {
            var result = 1;
            for (var i = value; i > 1; i--)
            {
                result *= i;
            }

            return result;
        }

        public int RecursionFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * RecursionFactorial(n - 1);
        }
    }
}