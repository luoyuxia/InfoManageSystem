using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoManageSystem.ViewModel.Model
{

    //单个经销商固定时间段的进货总金额
    public class DealersStatistic
    {
        public int DealersId { get; set; }
        public string DealersName { get; set; }

        public string DateSlot { get; set; }
        public decimal TotalMoney { get; set; }
    }
}
