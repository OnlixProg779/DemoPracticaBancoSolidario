using System.Linq.Expressions;


namespace BancoSolidario.ExtendApplication.Specifications
{
    public interface ISpecification<T>
    {
        List<Expression<Func<T, bool>>> Criteria { get; } 
        List<Expression<Func<T, object>>> Includes { get; }

        //OrderByModel OrderByModel { get; }

        int Take { get; } 
        int Skip { get; } 

        bool IsPagingEnable { get; }

    }
}
