using Microsoft.AspNetCore.Mvc;

namespace EmberTripsPage.Controllers
{

    [ApiController]
    [Route("v1")]
    public class EmberApiController : Controller
    {
        [HttpGet("quotes")]
        public ActionResult Quotes([FromQuery] int origin, [FromQuery] int destination, [FromQuery] DateTime departureFrom, [FromQuery] DateTime departureTo)
        {
            var fp = Path.Combine(Directory.GetCurrentDirectory(), "Fixtures", "quotes-result.json");
            var jsonData = System.IO.File.ReadAllText(fp);

            return new OkObjectResult(jsonData);
        }

        [HttpGet("trips/{tripUid}")]
        public ActionResult Trips(string tripUid)
        {
            var fp = Path.Combine(Directory.GetCurrentDirectory(), "Fixtures", "trips-result.json");
            var jsonData = System.IO.File.ReadAllText(fp);

            return new OkObjectResult(jsonData);
        }
    }
}
