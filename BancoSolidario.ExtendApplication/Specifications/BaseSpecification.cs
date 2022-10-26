using System.Linq.Expressions;

namespace BancoSolidario.ExtendApplication.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
            Criteria = new List<Expression<Func<T, bool>>>();
        }

        public BaseSpecification(List<Expression<Func<T, bool>>> criteria)
        {
            Criteria = criteria;
        }

        public List<Expression<Func<T, bool>>> Criteria { get; } 

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        //public OrderByModel OrderByModel { get; set; } = new OrderByModel();

        //protected void AddOrderByMappingStrings(string orderBy)
        //{
        //    OrderByModel.OrderBy = orderBy;
        //}

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnable { get; private set; }


        protected void ApplyPaging(int skip, int take, bool isPaging = true)
        {
            Skip = skip;
            Take = take;
            IsPagingEnable = isPaging;
        }


    }
}
