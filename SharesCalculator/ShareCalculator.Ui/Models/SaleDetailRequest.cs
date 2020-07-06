using System;
using System.ComponentModel.DataAnnotations;

namespace ShareCalculator.Ui.Models
{
    /// <summary>
    /// Share sale details HTTP request.
    /// </summary>
    public class SaleDetailRequest
    {
        /// <summary>
        /// Sold share count. 
        /// </summary>
        [Required(ErrorMessage = "share count is mandatory.")]
        [Range(10, int.MaxValue , ErrorMessage ="Count shoud be greater than zeo.")]
        public int Count { get; set; }

        /// <summary>
        /// Price per share.
        /// </summary>
        [Required(ErrorMessage = "Shares sale price is mandatory.")]
        public double PricePerShare { get; set; }

        /// <summary>
        /// Date & time of the share sale.
        /// </summary>
        
        [Required( ErrorMessage ="Shares sale date is mandatory." )]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }

}
