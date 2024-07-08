using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7.Models
{
    public class SaleItemsResponse
    {
        public List<string> Categories { get; set; }
        public List<SaleItem> Items { get; set; }
    }
}
