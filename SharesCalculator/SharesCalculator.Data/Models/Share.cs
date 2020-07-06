using System;

namespace SharesCalculator.Data.Models
{
    /// <summary>
    /// Share entity for data provider
    /// </summary>
    public class Share
    {
        /// <summary>
        /// Share identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the share
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// total count while buying
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Date time while buying share
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Price of the share
        /// </summary>
        public double Price { get; set; }
    }
}
