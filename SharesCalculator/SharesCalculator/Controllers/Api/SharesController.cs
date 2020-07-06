using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharesCalculator.Api.Models;
using SharesCalculator.Business;
using SharesCalculator.Business.Models;

namespace SharesCalculator.Api.Controllers.Api
{
    /// <summary>
    /// Share controller, Handles shares specific HTTP / HTTPS API's
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class SharesController : ControllerBase
    {


        private readonly ILogger<SharesController> _logger;
        private readonly IShareSaleBusiness _shareSaleBusiness;
        private readonly IMapper _mapper;

        public SharesController(IShareSaleBusiness shareSaleBusiness , ILogger<SharesController> logger, IMapper mapper)
        {
            _shareSaleBusiness = shareSaleBusiness ?? throw new ArgumentNullException(nameof(shareSaleBusiness));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        
        /// <summary>
        /// Get all available shares.
        /// </summary>
        /// <returns>Returns all shares and its details.</returns>
        [HttpGet]
        public ActionResult GetAsync()
        {

            var result = _shareSaleBusiness.GetShares();

            return Ok(result);
        }


        /// <summary>
        /// Calculate the shares sales for SaleDetailRequest.
        /// </summary>
        /// <param name="saleDetailRequest"></param>
        /// <returns>Returns ShareInfo based on SaleDetailRequest. </returns>

        [HttpPost]
        [Route("calculate-fifo-method")]
        public ActionResult PostAsync(SaleDetailRequest  saleDetailRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest( ModelState.Values);
            }

            try
            {
                // Auto mapper maps HTTP request Models to business models
                var saleDetail = _mapper.Map<SaleDetail>(saleDetailRequest);

                var shareInfo = _shareSaleBusiness.Calculate(saleDetail);

                return Ok(shareInfo);

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
