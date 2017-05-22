using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;
using InfoManageSystem.Domain.Abstract;
namespace InfoManageSystem.Service.Service
{
    public class WareHouseService : IWareHouseService
    {
        private IWareHouseRespository wareHouseRespository;
        public WareHouseService(IWareHouseRespository wareHouseRespository)
        {
            this.wareHouseRespository = wareHouseRespository;
        }
        public bool DeleteWareHosue(int wareHosueId)
        {
            WareHouse wareHouse = wareHouseRespository.GetWareHouseById(wareHosueId);
            if (wareHouse == null)
                return false;
            //如果仓库存有商品的话，拒绝删除该仓库
            if ((wareHouse.GoodsStorages.Sum(s => s.Quantity)) > 0)
                return false;
            return wareHouseRespository.DeleteWareHouse(wareHosueId);

        }

        public IEnumerable<WareHouse> GetAllWareHouse(int offset, int pageSize, out int total)
        {
            total = wareHouseRespository.WareHouse.Count();
            return wareHouseRespository.WareHouse.OrderBy(w => w.Id).Skip(pageSize * (offset - 1)).Take(pageSize).AsEnumerable();
        }

        public WareHouse GetSingleWareHouse(int wareHouseId)
        {
            return wareHouseRespository.GetWareHouseById(wareHouseId);
        }

        public bool SaveWareHosue(WareHouse wareHouse)
        {
            return wareHouseRespository.SaveWareHosue(wareHouse);
        }

        public IEnumerable<WareHouse> GetAllWareHouse()
        {
            return wareHouseRespository.WareHouse.AsEnumerable();
        }

        public bool HasEnoughGoods(int wareHouseId, int goodsId, int quantity)
        {
            WareHouse wareHouse = wareHouseRespository.GetWareHouseById(wareHouseId);
            int totalQuantity = wareHouse.GoodsStorages.Where(s => s.GoodsId == goodsId).Sum(s => s.Quantity);
            return totalQuantity >= quantity;
        }
    }
}
