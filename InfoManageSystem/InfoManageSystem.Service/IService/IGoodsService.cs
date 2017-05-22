using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Service.IService
{
    public interface IGoodsService
    {
        Goods GetSingleGoods(int GoodsID);

        bool DeleteGoods(int GoodsID);

        bool SaveGoods(Goods goods);

        IEnumerable<Goods> GetAllGoodsByName(string GoodsName);

        IEnumerable<Goods> GetGoodsPageable(int offest, int pageSize, out int total);

        IEnumerable<Goods> GetAllGoodsPageableByName(int offset, int pageSize, string name, out int total);
    }
}
