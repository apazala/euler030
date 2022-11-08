internal class Program
{

    static int[] digPowers = new int[10];
    static int solutionSum = 0;
    private static void Main(string[] args)
    {
        digPowers[0] = 0; //Redundant for clarity
        digPowers[1] = 1;
        for(int i = 2; i <= 9; i++){
            int dPow = i*i;
            dPow*=dPow;
            dPow*=i; //Comment this to get the example solution
            digPowers[i] = dPow;
        }

        DepthSearch(0, 0, 0);

        Console.WriteLine($"{solutionSum-1}");
    }

    private static void DepthSearch(int digit, int number, int sum)
    {
        //Consider n digits when n*9^5 >= 10^(n-1); 1 + 5log10(9) >= n - log10(n); n <= 7
        if(digit == 7){
            if(number == sum){
                Console.WriteLine($"Found!: {sum}");
                solutionSum+=sum;
            }
            return;
        }

        digit++;
        number*=10;
        for(int d = 0; d <= 9; d++){
            DepthSearch(digit, number + d, sum + digPowers[d]);
        }
    }
}