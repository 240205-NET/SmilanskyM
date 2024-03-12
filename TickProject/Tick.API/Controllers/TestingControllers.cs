using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MyAppController : ControllerBase
	{
		[HttpGet]
		public ActionResult<string> Get()
		{
			// Call your console app logic here and return a result
			return "Hello from my console app!";
		}
	}
}
