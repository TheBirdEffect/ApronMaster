using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /*
        This controller provides all basic functions
        which all controllers should inherit from.
        It provides the only the route of the APIs
        for all orther Controllers. 
    */
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase{}
}