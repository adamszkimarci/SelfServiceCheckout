namespace SelfServiceCheckout.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;
        private readonly ICheckoutService _chekoutService;

        public CheckoutController(ILogger<StockController> logger, ICheckoutService chekoutService)
        {
            _logger = logger;
            _chekoutService = chekoutService;
        }

        [HttpPost]
        public async Task<ActionResult<Dictionary<string, int>>> PostCheckout([FromBody] Checkout checkout)
        {
            Dictionary<string, int> changeToReturn = await _chekoutService.PostCheckout(checkout);
            if(changeToReturn != null)
            {
                _logger.LogInformation("Successful checkout");
                return Ok(changeToReturn);
            }
            else
            {
                _logger.LogError("Error during checkout");
                return BadRequest();
            }
        }
    }
}
