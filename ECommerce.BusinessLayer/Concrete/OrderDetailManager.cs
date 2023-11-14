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
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;
        public void TAdd(OrderItem t)
        {
            _orderDetailDal.Insert(t);
        }

        public void TDelete(OrderItem t)
        {
           _orderDetailDal.Delete(t);
        }

        public OrderItem TGetByID(int id)
        {
            return _orderDetailDal.GetByID(id);
        }

        public List<OrderItem> TGetList()
        {
            return _orderDetailDal.GetList();
        }

        public List<OrderItem> TGetListbyFilter(int id)
        {
            return _orderDetailDal.GetByFilter(x => x.Id == id);
        }

        public void TUpdate(OrderItem t)
        {
            _orderDetailDal.Update(t);
        }
    }
}
