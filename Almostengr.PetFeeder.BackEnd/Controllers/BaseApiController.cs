using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected BaseApiController(ILogger<BaseApiController> logger)
        {
        }
        
    }
}
