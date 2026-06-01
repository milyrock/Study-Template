using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 1. Использует Monitor (lock) для синхронизации
/// </summary>
public sealed class MonitorService : IPrimeCounter
{
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        var numberAmount = end - start + 1;
        var rangePerThread = numberAmount / threadCount;
        var syncObject = new object();
        var foundPrimeCount = 0;
        List<Thread> workerThreads = new();

        var stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < threadCount; i++)
        {
            var workerNumber = i;


            var thread = new Thread(() =>
            {
                for (int candidateNumber = start + rangePerThread * workerNumber; candidateNumber < rangePerThread * (workerNumber + 1) + start; candidateNumber++)
                {
                    Console.WriteLine($"Thread: {workerNumber} - checks {candidateNumber}");
                    if (IsPrime(candidateNumber))
                    {
                        lock (syncObject)
                        {
                            foundPrimeCount++;
                        }

                        Console.WriteLine($"Thread {workerNumber} found {candidateNumber}");
                    }
                }
            });

            workerThreads.Add(thread);
            thread.Start();
        }

        foreach (var thread in workerThreads)
        {
            thread.Join();
        }

        stopwatch.Stop();

        return new PrimeCountResultDto { PrimeCount = foundPrimeCount, ExecutionTime = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds) };
    }

    public bool IsPrime(int candidateNumber)
    {
        if (candidateNumber < 2) return false;
        if (candidateNumber == 2) return true;
        if (candidateNumber % 2 == 0) return false;

        int maxDivider = (int)Math.Sqrt(candidateNumber);
        for (int divider = 3; divider <= maxDivider; divider += 2)
            if (candidateNumber % divider == 0)
                return false;

        return true;
    }

    public string GetVersionName() => "Monitor";
}
