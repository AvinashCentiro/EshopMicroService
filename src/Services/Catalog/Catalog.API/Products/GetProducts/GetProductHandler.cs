
namespace Catalog.API.Products.GetProducts
{
    public record GetProductQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductResult>; // IQuery<GetProductResult> we should get response which type is GetproductResult.

    public record GetProductResult(IEnumerable<Product> Products);  // returning the enumerable product response i.e returning Products from our result object


    //These record types represent to request for fetching products and the structure of the data that we  expect to return.

    internal class GetProductQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProductQuery, GetProductResult>
    {
        //in the query handler as a request we will set GetProductsQuery And as a response we will return GetProductsResult.
        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToPagedListAsync(query.PageNumber ?? 1,query.PageSize?? 10, cancellationToken);
            
            return new GetProductResult(products);
        }
    }
}
