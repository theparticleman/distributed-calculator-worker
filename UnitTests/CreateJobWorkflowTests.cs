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
        var request = new CreateJobRequest
        {
            JobId = Guid.NewGuid(),
            Calculation = "CALCULATE: calculation"
        };

        var jobRepositoryMock = new Mock<IJobRepository>();
        var jobProcessorMock = new Mock<IJobProcessor>();
        jobProcessorMock.Setup(x => x.Calculate("calculation")).Returns("result");

        var classUnderTest = new CreateJobWorkflow(jobRepositoryMock.Object, jobProcessorMock.Object);

        var result = classUnderTest.CreatJob(request);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.JobId, Is.EqualTo(request.JobId));
        Assert.That(result.Result, Is.EqualTo("result"));
        jobRepositoryMock.Verify(x => x.SaveJob(request.JobId, request.Calculation, "result"));
    }
}
