using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator_worker;

public class ErrorCheckController : ControllerBase
{
    private readonly IJobRepository jobRepository;

    public ErrorCheckController(IJobRepository jobRepository)
    {
        this.jobRepository = jobRepository;
    }

    [HttpPost("error-check")]
    public IActionResult ErrorCheck([FromBody] ErrorCheckRequest request)
    {
        Console.WriteLine("ERROR CHECK");
        Console.WriteLine(request);
        var job = jobRepository.Load(request.JobId);
        Console.WriteLine("Job with error: " + job);
        return Ok();
    }
}