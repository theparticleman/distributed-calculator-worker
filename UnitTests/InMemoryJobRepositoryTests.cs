using System;
using NUnit.Framework;

namespace distributed_calculator_worker;

public class InMemoryJobRepositoryTests
{
    [Test]
    public void Round_trip_test()
    {
        var classUnderTest = new InMemoryJobRepository();
        var jobId = Guid.NewGuid();

        classUnderTest.SaveJob(jobId, "calculation", "result");

        var loadedJob = classUnderTest.Load(jobId);

        Assert.That(loadedJob, Is.Not.Null);
    }
}