using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using SharesCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using SharesCalculator.Business.Models;
using SharesCalculator.Data.Models;

namespace SharesCalculator.Business
{
    /// <summary>
    /// Shares business logics.
    /// </summary>
    public class ShareSaleBusiness : IShareSaleBusiness
    {
        protected readonly ILogger<ShareSaleBusiness> _logger;
        protected readonly IShareData _shareData;
       public ShareSaleBusiness(IShareData shareData, ILogger<ShareSaleBusiness> logger)
        {
            _shareData = shareData ?? throw new ArgumentNullException(nameof(shareData));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        /// <summary>
        /// Get all available shares.
        /// </summary>
        /// <returns>Returns all shares.</returns>
        public IList<Share> GetShares()
        {
            return _shareData.GetShares();
        }
        /// <summary>
        /// Calculate remaining share details based on sold shares.
        /// </summary>
        /// <param name="saleDetail"></param>
        /// <returns>Returns available share details.</returns>
        public ShareInfo Calculate(SaleDetail saleDetail)
        {
            if(saleDetail == null)
            {
                throw new ArgumentNullException(nameof(saleDetail));
            }

            if(saleDetail.Count <= 0)
            {
                throw new ValidationException("Sold shares count cannot be zero or lower.");
                
            }

            if (saleDetail.PricePerShare <= 0)
            {
                throw new ValidationException("Sold shares price cannot be zero or lower.");
            }
            
            if(saleDetail.Date > DateTime.Now)
            {
                throw new ValidationException("Shares sold date time cannot be greater than current time. ");
            }

            // Get data from shares object data.
            var shares = _shareData.GetShares();

            var totalSharesCount = shares.Sum(share => share.Count);

            if (totalSharesCount < saleDetail.Count)
            { 
                throw new ValidationException("Sold shares count cant be greater than total available shares count.");
            }

            var firstShare = shares.FirstOrDefault();

            if(firstShare == null)
            {
                throw new NullReferenceException("There is no shares available.");
            }
           

            var shareInfo = new ShareInfo();

            shareInfo.CostPriceOfSoldShares = firstShare.Price;

            shareInfo.GainOrLossInPrice = (saleDetail.PricePerShare - firstShare.Price) * saleDetail.Count;

            shareInfo.NoOfRemainingShares = totalSharesCount - saleDetail.Count;

            shareInfo.CostPriceOfRemainingShares = GetRemainingSharesCostPrice(shares, saleDetail.Count);

            return shareInfo;

        }


        Func<IList<Share>, int, double> GetRemainingSharesCostPrice = (shares, count) => {

            int temp = 0;

            foreach (var share in shares)
            {
                temp = temp + share.Count;

                if (temp > count)
                {
                    return share.Price;
                }
            }

            return 0;
        };
    }
}
