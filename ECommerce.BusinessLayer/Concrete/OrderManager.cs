using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TAdd(Order t)
        {
            _orderDal.Insert(t);
        }

        public void TDelete(Order t)
        {
            _orderDal.Delete(t);
        }

        public Order TGetByID(int id)
        {
           return _orderDal.GetByID(id);
        }

        public List<Order> TGetList()
        {
         return _orderDal.GetList();
        }

        public List<Order> TGetListbyFilter(int id)
        {
            return _orderDal.GetByFilter(x=> x.Id == id);
        }

        public void TUpdate(Order t)
        {
            _orderDal.Update(t);
        }
    }
}
