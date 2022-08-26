namespace distributed_calculator_worker;

public interface ICreateJobWorkflow
{
    CreateJobResponse CreatJob(CreateJobRequest request);
}

public class CreateJobWorkflow : ICreateJobWorkflow
{
    private readonly IJobRepository jobRepository;
    private readonly IJobProcessor jobProcessor;

    public CreateJobWorkflow(IJobRepository jobRepository, IJobProcessor jobProcessor)
    {
        this.jobRepository = jobRepository;
        this.jobProcessor = jobProcessor;
    }

    public CreateJobResponse CreatJob(CreateJobRequest request)
    {
        var calculation = request.Calculation.Replace("CALCULATE: ", "");
        var result = jobProcessor.Calculate(calculation);
        jobRepository.SaveJob(request.JobId, request.Calculation, result);
        return new CreateJobResponse
        {
            JobId = request.JobId,
            Result = result
        };
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