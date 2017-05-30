using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoManageSystem.Domain.Entities
{
    public class QueryModel
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public string SortField { get; set; }
        public string Order { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
