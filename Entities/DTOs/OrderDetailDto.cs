using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderDetailDto:IDto
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int ItemId { get; set; }


        public string StateName { get; set; }

        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
