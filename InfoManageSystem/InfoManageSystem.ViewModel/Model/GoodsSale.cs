using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoManageSystem.ViewModel.Model
{
    public class GoodsSale
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalSaleMoney { get; set; }
    }
}
