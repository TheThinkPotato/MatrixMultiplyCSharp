using System.Diagnostics;

internal class Program
{

    const int N = 1000;
    const int RUNS = 3;
    const int Seed = 42;
    

    private static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        double[,] A = new double[N,N];
        double[,] B = new double[N, N];
        double[,] C = new double[N, N];

        generateArray(ref A, ref B);
        stopwatch.Start();
        
        // Matrix multiply by the amount of runs.
        for (int i = 0; i < RUNS; i++)
        {
            multiplyArrays(ref A, ref B, ref C);            
        }
        
        stopwatch.Stop();

        TimeSpan elapsed = stopwatch.Elapsed;
        Console.WriteLine($"Elapsed time: {elapsed.TotalSeconds} s.\nWith {RUNS} runs of a {N}x{N} matrix.");
    }


    public static void multiplyArrays(ref double[,] A, ref double[,] B, ref double[,] result)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                for (int k = 0; k < N; k++)
                {
                    result[i, j] += A[i, k] * B[k, j];
                }
            }
        }        
    }

    public static void generateArray(ref double[,] A, ref double[,] B)
    {
        Random random = new Random(Seed);

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                A[i, j] = random.Next();
                B[i, j] = random.Next();
            }
        }
    }


    public static void displayArray(ref double[,] arrayDisplay)
    {

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.WriteLine($"Row:{i}, Col:{j} > {arrayDisplay[i, j]}");                
            }
        }
    }

}