using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class MonitorServiceTests
{
    private MonitorService _monitorService;

    [SetUp]
    public void SetUp()
    {
        _monitorService = new MonitorService();
    }

    [Test]
    public void CountPrimes_WithValidRange_ReturnsCorrectPrimeCount()
    {
        // Arrange
        int rangeStart = 1;
        int rangeEnd = 10000;
        int threadAmount = 4;
        int expectedPrimeAmount = 1229;

        // Act
        var result = _monitorService.CountPrimes(rangeStart, rangeEnd, threadAmount);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(1229));
    }


    [Test]
    public void CountPrimes_SingleThread_ReturnsCorrectPrimeCount()
    {
        // Arrange
        int rangeStart = 1;
        int rangeEnd = 1000;
        int threadAmount = 1;
        int expectedPrimeAmount = 168;

        // Act
        var result = _monitorService.CountPrimes(rangeStart, rangeEnd, threadAmount);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(expectedPrimeAmount));
    }

    [Test]
    public void CountPrimes_SmallRange_ReturnsCorrectPrimeCount()
    {
        // Arrange
        int rangeStart = 1;
        int rangeEnd = 100;
        int threadAmount = 4;
        int expectedPrimeAmount = 25;

        // Act
        var result = _monitorService.CountPrimes(rangeStart, rangeEnd, threadAmount);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(expectedPrimeAmount));
    }
}
