using Microsoft.AspNetCore.Mvc;

namespace OneTimeAccessService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OneTimeAccessController : Controller
    {
        [Route("GetNew")]
        [HttpGet]
        public IActionResult GetOneTimeAccessToken()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        public IActionResult VerifyOneTimeAccessToken()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
