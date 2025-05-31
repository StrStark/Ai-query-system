using Microsoft.AspNetCore.Mvc;

namespace databasTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesQueryController : ControllerBase
    {
        private readonly SalesQueryService _service;

        public SalesQueryController(SalesQueryService service)
        {
            _service = service;
        }

        [HttpGet("query")]
        public IActionResult QuerySales(
            DateTime? from,
            DateTime? to,
            int? productId,
            decimal? minRevenue,
            decimal? maxDiscount,
            short? minQty
        )
        {
            var result = _service.GetFilteredSales(from, to, productId, minRevenue, maxDiscount, minQty);
            return Ok(result);
        }
    }


}
