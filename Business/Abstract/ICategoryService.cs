using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICategoryService
{
    IDataResult<Category> GetById(int productId);
    IDataResult<List<Category>> GetList();
    IDataResult<Category> GetByProductId(int productId);
    IResult Add(Category category);
    IResult Delete(Category category);
    IResult Update(Category category);
}