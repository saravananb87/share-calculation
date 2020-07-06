using System;


namespace SharesCalculator.Business.Models
{

    /// <summary>
    /// Share sale details.
    /// </summary>
    public class SaleDetail
    {
        /// <summary>
        /// Sold share count. 
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Price per share.
        /// </summary>
        public double PricePerShare { get; set; }

        /// <summary>
        /// Date & time of the share sale.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
