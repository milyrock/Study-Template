using Study.LabWork1.Features.Task1;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1()
    {
        MyVector a = new (1, 2);
        MyVector b = new (3, 4);

        Console.WriteLine($"сумма {a + b}");
        Console.WriteLine($"длина {+a}");
        Console.WriteLine($"вычитание {a - b}");
        Console.WriteLine($"умножение {a * b}");
        Console.WriteLine($"равенство {a == b}");
        Console.WriteLine($"неравенство {a != b}");
    }

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
