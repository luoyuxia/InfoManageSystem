using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Abstract;

namespace InfoManageSystem.Domain.Concrete
{
    public class EFGoodsRespository : IGoodsRespository
    {
        EFDbContext context = new EFDbContext();
        public bool SaveGoods(Goods goods)
        {
            Goods dbEntry = context.Goods.Find(goods.Id);
            if(dbEntry == null)
            {
                context.Goods.Add(goods);
            }
            else
            {
                context.Entry(dbEntry).CurrentValues.SetValues(goods);
            }
            context.SaveChanges();
            return true;
        }

        public bool DeleteGoods(int GoodsId)
        {
            Goods goods = context.Goods.Find(GoodsId);
            if (goods == null)
                return false;
            else
            {
                context.Goods.Remove(goods);
                context.SaveChanges();
                return true;
            }
        }

        public IQueryable<Goods> Goods
        {
            get
            {
                return context.Goods;
            }
        }

        public Goods GetGoodsByID(int GoodsId)
        {
            return context.Goods.Find(GoodsId);
        }
    }
}
