using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;

namespace ECommerce.BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMedialDal;

        public SocialMediaManager(ISocialMediaDal socialMedialDal)
        {
            _socialMedialDal = socialMedialDal;
        }

        public void TAdd(SocialMedia t)
        {
            _socialMedialDal.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMedialDal.Delete(t);
        }

        public SocialMedia TGetByID(int id)
        {
           return _socialMedialDal.GetByID(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMedialDal.GetList();
        }

        public List<SocialMedia> TGetListbyFilter(int id)
        {
          return _socialMedialDal.GetByFilter(x=> x.Id == id);


        }

        public void TUpdate(SocialMedia t)
        {
            _socialMedialDal.Update(t);
        }
    }
}
