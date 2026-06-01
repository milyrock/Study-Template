using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

/// <summary>
/// Определяет реализацию для процессора наборов чисел
/// </summary>
public sealed class NumberSetProcessor(List<int[]> numberSets,
    int maxWorkerCount) : INumberSetProcessor
{
    private readonly List<int[]> _numberSets = numberSets;
    private readonly List<ResultEntryDto> _entries = [];
    private int _sumTotal = 0;
    private readonly object _syncObject = new();
    private readonly Mutex _syncMutex = new();
    private readonly Semaphore _syncSemaphore = new(maxWorkerCount, maxWorkerCount);
    private TimeSpan _elapsedTime = TimeSpan.Zero;



    public void Process()
    {
        var stopwatch = Stopwatch.StartNew();
        var threads = new List<Thread>();

        for (int i = 0; i < _numberSets.Count; i++)
        {
            int batchNumber = i + 1;
            int[] values = _numberSets[i];

            var thread = new Thread(() => ProcessDataSet(batchNumber, values));
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();
        _elapsedTime = stopwatch.Elapsed;
    }

    private void ProcessDataSet(int batchNumber, int[] values)
    {
        _syncSemaphore.WaitOne();

        try
        {
            int processorThreadId = Thread.GetCurrentProcessorId();
            int batchSum = 0;

            foreach (int numberValue in values)
            {
                batchSum += numberValue;
            }

            lock (_syncObject)
            {
                _entries.Add(new ResultEntryDto
                {
                    SetNumber = batchNumber,
                    Sum = batchSum,
                    ThreadId = processorThreadId
                });
            }

            _syncMutex.WaitOne();
            try
            {
                _sumTotal += batchSum;
            }
            finally
            {
                _syncMutex.ReleaseMutex();
            }
        }
        finally
        {
            _syncSemaphore.Release();
        }
    }

    public ProcessingResultDto GetResult()
    {
        return new ProcessingResultDto
        {
            Results = _entries,
            TotalSum = _sumTotal,
            ProcessedSetsCount = _entries.Count,
            ExecutionTime = _elapsedTime
        };
    }
}
