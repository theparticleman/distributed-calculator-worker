using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator_worker;

public class CreateJobController : ControllerBase
{
    private readonly ICreateJobWorkflow createJobWorkflow;

    public CreateJobController(ICreateJobWorkflow createJobWorkflow)
    {
        this.createJobWorkflow = createJobWorkflow;
    }

    [HttpPost("create-job")]
    public CreateJobResponse CreateJob([FromBody] CreateJobRequest request)
    {
        return createJobWorkflow.CreatJob(request);
    }
}