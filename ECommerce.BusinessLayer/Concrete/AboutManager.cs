using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;

namespace ECommerce.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
       private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About TGetByID(int id)
        {
           return _aboutDal.GetByID(id);
        }

        public List<About> TGetList()
        {
          return  _aboutDal.GetList();
        }

        public List<About> TGetListbyFilter(int id)
        {
          return _aboutDal.GetByFilter(x=> x.Id == id);
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
