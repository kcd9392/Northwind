using System.Linq.Expressions;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product,NorthWindContext>,IProductDal
{

}