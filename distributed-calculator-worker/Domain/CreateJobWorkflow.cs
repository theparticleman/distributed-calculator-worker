namespace distributed_calculator_worker;


public class CreateJobWorkflow
{
    private IJobRepository jobRepository;

    public CreateJobWorkflow(IJobRepository jobRepository)
    {
        this.jobRepository = jobRepository;
    }

    public CreateJobResponse CreatJob(CreateJobRequest request)
    {
        jobRepository.SaveJob(request.JobId, request.Calculation);
        return new CreateJobResponse();
    }
}

public record CreateJobResponse
{
    public Guid JobId { get; set; }
    public string Result { get; set; }
}

public record CreateJobRequest
{
    public Guid JobId { get; set; }
    public string Calculation { get; set; }
}