using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator_worker;

public class DiagnosticController : ControllerBase
{
    [Route("health-check")]
    public ActionResult HealthCheck()
    {
        return Ok("This is fine.");
    }
}