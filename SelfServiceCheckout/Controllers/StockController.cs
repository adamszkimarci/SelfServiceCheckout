namespace SelfServiceCheckout.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;
        private readonly IStockService _stockService;

        public StockController(ILogger<StockController> logger, IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }

        [HttpPost]
        public async Task<ActionResult<Dictionary<string, int>>> PostStock([FromBody] Dictionary<string, int> stock)
        {
            var stockToSave = await _stockService.PostStock(stock);
            if(stockToSave != null)
            {
                _logger.LogInformation("Succesfully added stock.");
                return Ok(stockToSave);
            }
            return BadRequest($"Something went wrong inserting {stock}");
        }

        [HttpGet]
        public async Task<ActionResult<Dictionary<string, int>>> GetStocks()
        {
            return Ok(await _stockService.GetStocks());
        }
    }
}
