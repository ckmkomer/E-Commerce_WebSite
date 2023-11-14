using Ecommerce.CoreLayer.EntityFramework;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {
            Context = context;
        }

        public Context Context { get; }

        public List<Product> GetProductListWithCategory()
        {
            using (var c = new Context())
                return c.Products.Include(p => p.Category).ToList();
        }
    }
}
