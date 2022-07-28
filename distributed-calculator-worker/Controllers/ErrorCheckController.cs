using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator_worker;

public class ErrorCheckController : ControllerBase
{
    [HttpPost("error-check")]
    public IActionResult ErrorCheck([FromBody] ErrorCheckRequest request)
    {
        Console.WriteLine("ERROR CHECK");
        Console.WriteLine(request);
        return Ok();
    }
}