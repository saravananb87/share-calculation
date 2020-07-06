
using SharesCalculator.Business.Models;
using SharesCalculator.Data.Models;
using System.Collections.Generic;

namespace SharesCalculator.Business
{
    /// <summary>
    /// Share business logics.
    /// </summary>
    public interface IShareSaleBusiness
    {
        /// <summary>
        /// Calculate remaining share details based on sold shares.
        /// </summary>
        /// <param name="saleDetail"></param>
        /// <returns>Returns available share details.</returns>
        ShareInfo Calculate(SaleDetail saleDetail);

        /// <summary>
        /// Get all available shares.
        /// </summary>
        /// <returns>Returns all shares.</returns>
        IList<Share> GetShares();
    }
}
