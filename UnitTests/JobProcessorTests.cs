using NUnit.Framework;

namespace distributed_calculator_worker;

public class JobProcessorTests
{
    [TestCase("844 + 212", "1056")]
    [TestCase("931 - 863", "68")]
    [TestCase("645 * 335", "216075")]
    [TestCase("776 / 338", "2.296")]
    [TestCase("-517 / 66", "-7.833")]
    public void CalculateTests(string calculation, string expectedResult)
    {
        var classUnderTest = new JobProcessor();
        var result = classUnderTest.Calculate(calculation);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void When_calculating_and_there_is_an_error()
    {
        var classUnderTest = new JobProcessor();
        var result = classUnderTest.Calculate("552");

        Assert.That(result, Is.EqualTo("ERROR"));
    }
}