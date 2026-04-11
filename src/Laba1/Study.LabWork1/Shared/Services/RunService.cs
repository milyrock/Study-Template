using Study.LabWork1.Features.Task1;
using Study.LabWork1.Shared.Abstractions;
using Study.LabWork1.Features.Task2;
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
    public void RunTask2() {
        ConcreteMediator mediator = new();
        ConcreteUser u1 = new(mediator, "u1");
        ConcreteUser u2 = new(mediator, "u2");

        mediator.user1 = u1;
        mediator.user2 = u2;

        u1.Send("hello from u1!");
        u2.Send("hello from u2!");
    }
    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
