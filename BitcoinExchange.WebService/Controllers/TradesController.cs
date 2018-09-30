using BitcoinExchange.ServiceLayer.DataTransferObjects;
using BitcoinExchange.ServiceLayer.Services;
using Infrastructure.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinExchange.WebService.Controllers
{
    [Route("api/[controller]")]
    public class TradesController : BaseController<TradeDto>
    {
        public TradesController(TradeService tradeService) : base(tradeService)
        {

        }
    }
}
