using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Domain.Abstract
{
    public interface IGoodsRespository
    {
        bool SaveGoods(Goods goods);

        bool DeleteGoods(int GoodsId);

        Goods GetGoodsByID(int GoodsId);

        IQueryable<Goods> Goods { get; }
    }
}
