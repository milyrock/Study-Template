using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

[TestFixture]
public sealed class NumberSetProcessorTests
{
    private List<int[]> _testDataSets;

    [SetUp]
    public void SetUp()
    {
        _testDataSets = new List<int[]>
        {
            new[] { 1, 2, 3, 4, 5 },
            new[] { 10, 20, 30, 40, 50 },
            new[] { 2, 4, 6, 8, 10 }
        };
    }

    [Test]
    public void Process_CompletesSuccessfully()
    {
        // Arrange
        var processor = new NumberSetProcessor(_testDataSets, 2);

        // Act
        processor.Process();
        var result = processor.GetResult();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(3));
    }

    [Test]
    public void Process_CorrectlyCalculatesAllSums()
    {
        // Arrange
        var expectedSums = new[] { 15, 150, 30 };
        var processor = new NumberSetProcessor(_testDataSets, 2);

        // Act
        processor.Process();
        var result = processor.GetResult();

        // Assert
        var actualSums = result.Results.Select(entry => entry.Sum).OrderBy(sum => sum).ToArray();
        Assert.That(actualSums, Is.EqualTo(expectedSums.OrderBy(sum => sum).ToArray()));
    }

    [Test]
    public void GetResult_BeforeProcessing_ReturnsEmptyResults()
    {
        // Arrange
        var processor = new NumberSetProcessor(_testDataSets, 2);

        // Act
        var result = processor.GetResult();

        // Assert
        Assert.That(result.Results, Is.Not.Null);
        Assert.That(result.Results.Count, Is.EqualTo(0));
        Assert.That(result.TotalSum, Is.EqualTo(0));
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(0));
    }
}
