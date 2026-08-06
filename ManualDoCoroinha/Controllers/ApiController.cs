using Microsoft.AspNetCore.Mvc;

namespace ManualDoCoroinha.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected new IActionResult Response(bool isValidOperation, object result = null)
        {
            if (isValidOperation)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = (List<string>)result
            });
        }
    }
}
