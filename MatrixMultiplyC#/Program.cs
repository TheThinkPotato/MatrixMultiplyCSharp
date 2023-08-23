using System.Diagnostics;

internal class Program
{

    const int N = 300;
    const int RUNS = 100;
    const int Seed = 42;
    

    private static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        double[,] A = new double[N,N];
        double[,] B = new double[N, N];
        double[,] C = new double[N, N];

        generateArray( A,  B);
        stopwatch.Start();
        
        // Matrix multiply by the amount of runs.
        for (int i = 0; i < RUNS; i++)
        {
            multiplyArrays( A,  B,  C);            
        }
        
        stopwatch.Stop();

        TimeSpan elapsed = stopwatch.Elapsed;
        Console.WriteLine($"Elapsed time: {elapsed.TotalSeconds} s.\nWith {RUNS} runs of a {N}x{N} matrix.");
    }


    public static void multiplyArrays( double[,] A,  double[,] B,  double[,] result)
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

    public static void generateArray( double[,] A,  double[,] B)
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


    public static void displayArray( double[,] arrayDisplay)
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