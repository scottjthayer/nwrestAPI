using System;
using System.Collections.Generic;

#nullable disable

namespace RestApiLab.Models
{
    public partial class TenMostExpensiveProduct
    {
        public string TenMostExpensiveProducts { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
