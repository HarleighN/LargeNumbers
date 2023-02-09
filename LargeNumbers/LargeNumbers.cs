
// Test Data: 78752594922464908963889065965014296703395712973412 + 47641887866288081682946781771914536488779256328210
// = 126,394,482,788,752,990,646,835,847,736,928,833,192,174,969,301,622

class LargeNumbers
{
    static void Main(string[] args)
    {
        Random r = new Random(0);
        string[] input = new string[10];

        for (int i = 0; i < input.Length; i++)
        {
            input[i] = RndNum(r);
        }

        foreach (string num in input)
        {
            Console.WriteLine(num + " +");
        }

        Console.Write("= ");
        Console.WriteLine(AddMultipleLargeNumbers(input));

    }
    static string AddLargeNumbers(string num1, string num2)
    {
        PrependToSameLength(num1, num2, out num1, out num2);

        string sum = "";
        int TempSum = 0, count = 0;
        bool carry = false;


        while (count < Math.Min(num1.Length, num2.Length))
        {
            if (carry)
            {
                TempSum = (num1[num1.Length - 1 - count] - 48 + num2[num2.Length - 1 - count] - 48) + 1;
                carry = false;
            }
            else
            {

                TempSum = (num1[num1.Length - 1 - count] - 48 + num2[num2.Length - 1 - count] - 48);
            }

            sum = (TempSum.ToString().ElementAt(TempSum.ToString().Length - 1).ToString()) + sum;

            if (TempSum >= 10)
                carry = true;

            count++;
        }

        if (carry)
            sum = "1" + sum;

        return sum;
    }

    static string AddMultipleLargeNumbers(string[] input)
    {
        string result = AddLargeNumbers(input[0], input[1]);

        for (int i = 2; i < input.Length; i++)
        {
            result = AddLargeNumbers(result, input[i]);
        }

        return result;
    }


    // From TizzyT566
    static void PrependToSameLength(string num1, string num2, out string newNum1, out string newNum2)
    {
        newNum1 = num1.PadLeft(Math.Max(num1.Length, num2.Length), '0');
        newNum2 = num2.PadLeft(Math.Max(num1.Length, num2.Length), '0');
    }


    // From TizzyT566
    static string RndNum(Random prng, int length = 50)
    {
        const string digits = "0123456789";
        char[] result = new char[length];
        result[0] = digits[prng.Next(1, digits.Length)];
        for (int i = 1; i < length; i++)
            result[i] = digits[prng.Next(0, digits.Length)];
        return new string(result);
    }
}
