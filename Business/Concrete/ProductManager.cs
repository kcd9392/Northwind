using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validations;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using FluentValidation;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
    
    
    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }

    [PerformanceAspect(5)]
    public IDataResult<List<Product>> GetList()
    {
        Thread.Sleep(5000);
        return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
    }

    
    [CacheAspect(10)]
    //[SecuredOperation("Product.List,Admin")]
    //[LogAspect(typeof(FileLogger))]
    [LogAspect(typeof(DatabaseLogger))]
    public IDataResult<List<Product>> GetListByCategory(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
    }

   
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Add(Product product)
    {
        //ValidationTool.Validate(new ProductValidator(),new ValidationContext<Product>(product));
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }

    public IResult Delete(Product product)
    {
        _productDal.Delete(product);
        return new SuccessResult(Messages.ProductDeleted);
    }

    public IResult Update(Product product)
    {
        _productDal.Update(product);
        return new SuccessResult(Messages.ProductUpdated);
    }

    [TransactionScopeAspect]
    public IResult TransactionalOperation(Product product)
    {
        _productDal.Update(product);
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductUpdated);
    }
}