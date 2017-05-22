using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoManageSystem.Domain.Entities
{
    public class GoodsStorageInfo
    {
        public int GoodsId { get; set; }

        public string GoodsName { get; set; }

        public int WareHouseId { get; set; }

        public string WareHouseName { get; set; }
        public string WareHouseAddress { get; set; }

        public int Quantity { get; set; }
    }
}
