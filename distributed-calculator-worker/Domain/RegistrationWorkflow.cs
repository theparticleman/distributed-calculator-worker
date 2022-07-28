using Emmersion.Http;
using HttpMethod = Emmersion.Http.HttpMethod;
using HttpRequest = Emmersion.Http.HttpRequest;

namespace distributed_calculator_worker;

public interface IRegistrationWorkflow
{
    Task<RegistrationResult> RegisterAsync(RegistrationRequest registrationRequest);
}

public class RegistrationWorkflow : IRegistrationWorkflow
{
    private readonly IHttpClient httpClient;

    public RegistrationWorkflow(IHttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<RegistrationResult> RegisterAsync(RegistrationRequest registrationRequest)
    {
        var request = new HttpRequest
        {
            Url = registrationRequest.RegisterEndpoint,
            Method = HttpMethod.POST
        };
        request.AddJsonBody(new
        {
            registrationRequest.WorkerId,
            registrationRequest.TeamName,
            registrationRequest.CreateJobEndpoint,
            registrationRequest.ErrorCheckEndpoint
        });
        var response = await httpClient.ExecuteAsync(request);
        if (response.StatusCode == 200) return RegistrationResult.Success;
        return RegistrationResult.Failure;
    }
}

public record RegistrationRequest
{
    public string RegisterEndpoint { get; set; }
    public Guid WorkerId { get; set; }
    public string TeamName { get; set; }
    public string CreateJobEndpoint { get; set; }
    public string ErrorCheckEndpoint { get; set; }
}

public enum RegistrationResult
{
    Failure,
    Success
}