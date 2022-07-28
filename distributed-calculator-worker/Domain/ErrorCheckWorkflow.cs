namespace distributed_calculator_worker;

public record ErrorCheckRequest
{
    public Guid JobId { get; set; }
    public string ErrorMessage { get; set; }
}