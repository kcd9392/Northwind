using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;


namespace DataAccess.Concrete.EntityFramework.Contexts;

public class EfUserDal : EfEntityRepositoryBase<User,NorthWindContext>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using (var context = new NorthWindContext())
        {
            var result = from operationClaim in context.OperationClaims
                join userOperationClaim in context.UserOperationClaims
                    on operationClaim.Id equals userOperationClaim.OperationClaimId
                where userOperationClaim.UserId == user.Id
                select new OperationClaim
                {
                    Id = operationClaim.Id,
                    Name = operationClaim.Name
                };
            return result.ToList();

        }
    }
}