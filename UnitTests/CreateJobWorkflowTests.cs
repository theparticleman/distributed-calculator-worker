using System;
using distributed_calculator_worker;
using NUnit.Framework;
using Moq;

namespace UnitTests;

public class CreateJobWorkflowTests
{
    [Test]
    public void When_creating_a_job()
    {
        var jobRepositoryMock = new Mock<IJobRepository>();
        var classUnderTest = new CreateJobWorkflow(jobRepositoryMock.Object);
        var request = new CreateJobRequest
        {
            JobId = Guid.NewGuid(),
            Calculation = "calculation"
        };

        var result = classUnderTest.CreatJob(request);

        Assert.That(result, Is.Not.Null);
        jobRepositoryMock.Verify(x => x.SaveJob(request.JobId, request.Calculation));
    }
}
