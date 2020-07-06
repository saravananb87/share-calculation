using SharesCalculator.Data.Models;
using System.Collections.Generic;

namespace SharesCalculator.Data
{
    /// <summary>
    /// IShareData, Manage shares related database operations.
    /// </summary>
    public interface IShareData
    {
        /// <summary>
        /// Get available shares details.
        /// </summary>
        /// <returns>List of shares and details.</returns>
        IList<Share> GetShares();
    }
}
