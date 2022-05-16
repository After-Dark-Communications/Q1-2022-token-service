using Microsoft.AspNetCore.Mvc;
using OneTimeAccess.IServices;
using OneTimeAccess.Services;

namespace OneTimeAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OneTimeAccessController : Controller
    {
        private readonly IOneTimeAccessService _oneTimeAccessService;

        public OneTimeAccessController(IOneTimeAccessService oneTimeAccessService)
        {
            _oneTimeAccessService = oneTimeAccessService;
        }

        [HttpGet("GetNew")]
        public IActionResult GetOneTimeAccessToken()
        {
            try
            {
                string response = _oneTimeAccessService.GetNewOneTimeAccessToken();
                
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Verify")]
        public IActionResult VerifyOneTimeAccessToken(string token)
        {
            try
            {
                bool verificationResult = _oneTimeAccessService.VerifyOneTimeAccessToken(token);
                return Ok(verificationResult);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
