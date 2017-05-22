using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.Service.IService;
using InfoManageSystem.Domain.Entities;
using System.Linq.Expressions;

namespace InfoManageSystem.Service.Service
{
    public class GoodsService : IGoodsService
    {
        IGoodsRespository goodsRespository;
        IWareHouseRespository wareHouseRespository;
        public GoodsService(IGoodsRespository goodsRespository,IWareHouseRespository wareHouseRespository)
        {
            this.goodsRespository  = goodsRespository;
            this.wareHouseRespository = wareHouseRespository;
        }
        public bool DeleteGoods(int GoodsID)
        {
            return goodsRespository.DeleteGoods(GoodsID);
        }

        public IEnumerable<Goods> GetAllGoodsByName(string GoodsName)
        {
            return goodsRespository.Goods.Where(g => g.Name.Contains(GoodsName)).AsEnumerable();
        }

        //根据商品的名称分页得到所有的商品
        public IEnumerable<Goods> GetAllGoodsPageableByName(int offset, int pageSize, string name, out int total)
        {
            Expression<Func<Goods, bool>> express = g => g.Name.Contains(name);
            return getCategoryPageable(offset, pageSize, out total, express);
        }

        public IEnumerable<Goods> GetGoodsPageable(int offest, int pageSize, out int total)
        {
            Expression<Func<Goods, bool>> defaultExpress = g =>1 ==1;
            return getCategoryPageable(offest, pageSize,  out total,defaultExpress);
        }

        private IEnumerable<Goods> getCategoryPageable(int offset, int pageSize, out int totalCount, Expression<Func<Goods, bool>> whereLambda)
        {
            totalCount = goodsRespository.Goods.Where(whereLambda).Count();
            return goodsRespository.Goods.Where(whereLambda).OrderBy(c => c.Id).Skip(pageSize * (offset - 1)).Take(pageSize).AsEnumerable();
        }

        public Goods GetSingleGoods(int GoodsID)
        {
            return goodsRespository.GetGoodsByID(GoodsID);
        }

        public bool SaveGoods(Goods goods)
        {
            return goodsRespository.SaveGoods(goods);
        }

        //得到商品的库存信息
        public List<GoodsStorageInfo> GetGoodsWareHouseStorage(int offset,int pageSize,string name,out int total)
        {

            var query = goodsRespository.GoodsWareHouseStorage.Where(s=>s.GoodsName.Contains(name));
            total = query.Count();          
            return query.OrderBy(s => s.GoodsId).Skip((offset - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
