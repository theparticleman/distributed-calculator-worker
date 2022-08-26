namespace distributed_calculator_worker;

public interface IJobRepository
{
    public void SaveJob(Guid jobId, string calculation, string result);
    public Job Load(Guid jobId);
}

public class InMemoryJobRepository : IJobRepository
{
    private readonly List<Job> jobs = new List<Job>();

    public Job Load(Guid jobId)
    {
        return jobs.FirstOrDefault(x => x.JobId == jobId);
    }

    public void SaveJob(Guid jobId, string calculation, string result)
    {
        jobs.Add(new Job
        {
            JobId = jobId,
            Calculation = calculation,
            Result = result
        });
    }
}

public record Job
{
    public Guid JobId { get; set; }
    public string Calculation { get; set; }
    public string Result { get; set; }
}