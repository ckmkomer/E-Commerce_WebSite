using BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void TAdd(Service t)
        {
            _serviceDal.Insert(t);
        }

        public void TDelete(Service t)
        {
           _serviceDal.Delete(t);
        }

        public Service TGetByID(int id)
        {
            return _serviceDal.GetByID(id);
        }

        public List<Service> TGetList()
        {
           return _serviceDal.GetList();
        }

        public List<Service> TGetListbyFilter(int id)
        {
           return _serviceDal.GetByFilter(x=> x.Id == id);
        }

        public void TUpdate(Service t)
        {
           _serviceDal.Update(t);
        }
    }
}
