using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    public CategoryManager(ICategoryDal categoryDal = null)
    {
        _categoryDal = categoryDal ?? throw new ArgumentNullException(nameof(categoryDal));
    }

    private readonly ICategoryDal _categoryDal;

  

    public IDataResult<Category> GetById(int productId)
    {
        throw new NotImplementedException();
    }

    public IDataResult<List<Category>> GetList()
    {
        return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
    }

    public IDataResult<Category> GetByProductId(int productId)
    {
        throw new NotImplementedException();
    }

    public IResult Add(Category category)
    {
        throw new NotImplementedException();
    }

    public IResult Delete(Category category)
    {
        throw new NotImplementedException();
    }

    public IResult Update(Category category)
    {
        throw new NotImplementedException();
    }
}