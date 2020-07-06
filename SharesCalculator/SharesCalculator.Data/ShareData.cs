using SharesCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharesCalculator.Data
{
    /// <summary>
    /// ShareData, Manage shares related database operations.
    /// </summary>
    public class ShareData : IShareData
    {
        /// <summary>
        /// Build object data for local testing purpose.
        /// Ideally these details should be loaded from DbContext.
        /// </summary>
        /// <returns></returns>
        private static IList<Share> DataBuilder()
        {
            var shares = new List<Share>()
            {
                new Share(){ Id= Guid.NewGuid(), Name="Test1", Count=100, Date= new DateTime(2005,01,01) , Price=10.0 },
                 new Share(){ Id= Guid.NewGuid(), Name="Test2", Count=40, Date= new DateTime(2005,02,02), Price=12.0 },
                 new Share(){ Id= Guid.NewGuid(), Name="Test3", Count=50, Date= new DateTime(2005,03,03), Price=11.0 }

            };

            return shares;
        }

        /// <summary>
        /// Get available shares details.
        /// </summary>
        /// <returns>List of shares and details.</returns>
        public IList<Share> GetShares()
        {
            var shares = ShareData.DataBuilder();

            // Sorting shares based on date.
            return shares.OrderBy(x => x.Date).ToList<Share>();
        }


    }
}
