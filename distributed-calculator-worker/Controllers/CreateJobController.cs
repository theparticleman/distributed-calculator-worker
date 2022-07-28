using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator_worker;

public class CreateJobController : ControllerBase
{
    [HttpPost("create-job")]
    public IActionResult CreateJob([FromBody] CreateJobRequest request)
    {
        Console.WriteLine("CREATE JOB");
        Console.WriteLine(request);
        var response = new CreateJobResponse
        {
            JobId = request.JobId,
            Result = "???"
        };
        return Ok(response);
    }
}