using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator_worker;

public class RegistrationController : ControllerBase
{
    private readonly IRegistrationWorkflow registrationWorkflow;

    public RegistrationController(IRegistrationWorkflow registrationWorkflow)
    {
        this.registrationWorkflow = registrationWorkflow;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequest request)
    {
        Console.WriteLine(request);
        // var request = new RegistrationRequest
        // {
        //     RegisterEndpoint = "http://localhost:1234/register",
        //     WorkerId = Guid.NewGuid(),
        //     TeamName = "Jon's Team",
        //     CreateJobEndpoint = "http://localhost:5198/create-job",
        //     ErrorCheckEndpoint = "http://localhost:5198/error-check"
        // };
        var result = await registrationWorkflow.RegisterAsync(request);
        if (result == RegistrationResult.Success) return Ok();
        return BadRequest();
    }
}