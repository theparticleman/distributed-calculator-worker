namespace distributed_calculator_worker;

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