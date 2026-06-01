using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2;

public static class Program
{
    public static void Main()
    {
        var lockService = new MonitorService();
        var lockResult = lockService.CountPrimes(1, 10000, 10);

        Console.WriteLine($"Found {lockResult.PrimeCount} digits in {lockResult.ExecutionTime}ms");

        Console.WriteLine("==========");

        var mutexWorker = new MutexService();
        var mutexResult = mutexWorker.CountPrimes(1, 10000, 10);

        Console.WriteLine($"Found {mutexResult.PrimeCount} digits in {mutexResult.ExecutionTime}ms");

 
        Console.WriteLine("=============");

        var semaphoreWorker = new SemaphoreService();
        var semaphoreResult = semaphoreWorker.CountPrimes(1, 10000, 10);

        Console.WriteLine($"Found {semaphoreResult.PrimeCount} digits in {semaphoreResult.ExecutionTime}ms");
    }
}
