using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShareCalculator.Ui.Models;

namespace ShareCalculator.Ui.Controllers
{
    /// <summary>
    /// Shares UI cotroller
    /// </summary>
    public class SharesController : Controller
    {
        // GET: SharesController

        [HttpGet]
        public ActionResult Calculate()
        {
            return View();
        }


        // POST: SharesController/Calculate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Calculate(SaleDetailRequest  saleDetail)
        
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

                return BadRequest(messages);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    // This should come from IConfiguration.
                    var url = "https://localhost:6001/api/v1";
                    client.BaseAddress = new Uri(url);

                    string saleData = JsonConvert.SerializeObject(saleDetail);
                    StringContent httpContent = new StringContent(saleData, Encoding.UTF8, "application/json");

                    //HTTP POST
                    var response = await client.PostAsync(client.BaseAddress + "/shares/calculate-fifo-method", httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        var shareInfoResponse = JsonConvert.DeserializeObject<ShareInfoResponse>(responseContent);

                        return View("ShareInfo", shareInfoResponse);

                    }
                    else
                    {
                        return BadRequest(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
            
        }





    }
}
