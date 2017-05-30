using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Service.IService
{
    public interface IWareHouseService
    {
        WareHouse GetSingleWareHouse(int wareHouseId);

        IEnumerable<WareHouse> GetAllWareHouse(int offset, int pageSize, out int total);

        IEnumerable<WareHouse> GetAllWareHouse();

        bool DeleteWareHosue(int wareHosueId);

        bool SaveWareHosue(WareHouse wareHouse);

        //判断某个仓库的某件商品是否有足够的库存
        bool HasEnoughGoods(int wareHouseId, int goodsId, int quantity);

        //更新某件商品在仓库的库存
        bool UpdateGoodsStorage(int wareHouseId, int goodsId, int quantity);
    }
}
