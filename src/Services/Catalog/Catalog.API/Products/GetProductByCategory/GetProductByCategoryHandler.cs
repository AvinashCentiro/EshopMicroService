using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryQueryResult>;

    public record GetProductByCategoryQueryResult(IEnumerable<Product> Products);
    internal class GetProductByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryQueryResult>
    {
        public async Task<GetProductByCategoryQueryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
           var products= await session.Query<Product>()
               .Where(p=>p.Category.Contains(query.Category)).ToListAsync();

           return new GetProductByCategoryQueryResult(products);
        }
    }
}
