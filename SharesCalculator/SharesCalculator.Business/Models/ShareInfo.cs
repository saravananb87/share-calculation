using System;
using System.Collections.Generic;
using System.Text;

namespace SharesCalculator.Business.Models
{
    /// <summary>
    /// Share calculation response.
    /// </summary>
    public class ShareInfo
    {
        /// <summary>
        /// Cost pirce of the sold shares.
        /// </summary>
        public double CostPriceOfSoldShares { get; set; }

        /// <summary>
        /// Sold shares gain / loss in price.
        /// </summary>
        public double GainOrLossInPrice { get; set; }

        /// <summary>
        /// Remaining shares left after sales.
        /// </summary>
        public int NoOfRemainingShares { get; set; }

        /// <summary>
        /// Cost price of remaining shares.
        /// </summary>
        public double CostPriceOfRemainingShares { get; set; }

    }
}
