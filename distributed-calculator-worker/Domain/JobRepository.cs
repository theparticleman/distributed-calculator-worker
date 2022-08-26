namespace distributed_calculator_worker;

public interface IJobRepository
{
    public void SaveJob(Guid jobId, string calculation);
}