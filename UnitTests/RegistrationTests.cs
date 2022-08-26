using System;
using System.Threading.Tasks;
using distributed_calculator_worker;
using Emmersion.Http;
using Moq;
using NUnit.Framework;

namespace UnitTests;

public class RegistrationTests
{
    Mock<IHttpClient> httpClientMock;
    RegistrationWorkflow classUnderTest;

    [SetUp]
    public void SetUp()
    {
        httpClientMock = new Mock<IHttpClient>();

        classUnderTest = new RegistrationWorkflow(httpClientMock.Object);
    }

    [Test]
    public async Task When_registration_succeedsAsync()
    {
        IHttpRequest capturedRequest = null;
        httpClientMock.Setup(x => x.ExecuteAsync(It.IsAny<IHttpRequest>()))
            .Callback<IHttpRequest>(x => capturedRequest = x)
            .ReturnsAsync(new HttpResponse(200, null, null));
        
        var request = new RegistrationRequest
        {
            RegisterEndpoint = "http://coordinator.com/register",
            WorkerId = Guid.NewGuid(),
            TeamName = "my team",
            CreateJobEndpoint = "http://test.com/createJobEndpoint",
            ErrorCheckEndpoint = "http://test.com/errorCheckEndpoint"
        };
        var result = await classUnderTest.RegisterAsync(request);

        Assert.That(result, Is.EqualTo(RegistrationResult.Success));
        Assert.That(capturedRequest, Is.Not.Null);
        Assert.That(capturedRequest.Method, Is.EqualTo(HttpMethod.POST));
        Assert.That(capturedRequest.Url, Is.EqualTo(request.RegisterEndpoint));
        Assert.That(capturedRequest.HasContent(), Is.True);
        var requestContent = await capturedRequest.GetContent().ReadAsStringAsync();
        Assert.That(requestContent, Does.Contain(request.TeamName));
        Assert.That(requestContent, Does.Contain(request.WorkerId.ToString()));
        Assert.That(requestContent, Does.Contain(request.CreateJobEndpoint));
        Assert.That(requestContent, Does.Contain(request.ErrorCheckEndpoint));
    }

    [Test]
    public async Task When_registration_failsAsync()
    {
        httpClientMock.Setup(x => x.ExecuteAsync(It.IsAny<IHttpRequest>())).ReturnsAsync(new HttpResponse(400, null, null));
        var result = await classUnderTest.RegisterAsync(new RegistrationRequest());

        Assert.That(result, Is.EqualTo(RegistrationResult.Failure));
    }
}