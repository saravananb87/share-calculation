using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShareCalculator.Ui.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace ShareCalculator.Ui.Controllers
{
    /// <summary>
    /// Shares UI cotroller
    /// </summary>
    public class SharesController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger<SharesController> _logger;
        public SharesController(IConfiguration configuration, ILogger<SharesController> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // GET: SharesController

        [HttpGet]
        public ActionResult Calculate()
        {
            return View();
        }


        // POST: SharesController/Calculate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Calculate(SaleDetailViewModel  saleDetail)
        
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

                _logger.LogError(messages);

                return BadRequest(messages);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    // This should come from IConfiguration.
                    var url = _configuration["ApiBaseUrl"];
                    client.BaseAddress = new Uri(url);

                    string saleData = JsonConvert.SerializeObject(saleDetail);
                    StringContent httpContent = new StringContent(saleData, Encoding.UTF8, "application/json");

                    //HTTP POST
                    var response = await client.PostAsync(client.BaseAddress + "/shares/calculate-fifo-method", httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        var shareInfoResponse = JsonConvert.DeserializeObject<ShareInfoViewModel>(responseContent);

                        return View("ShareInfo", shareInfoResponse);

                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        _logger.LogError(message);
                        return BadRequest(message);
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(ex.StackTrace);
            }
            
        }





    }
}
