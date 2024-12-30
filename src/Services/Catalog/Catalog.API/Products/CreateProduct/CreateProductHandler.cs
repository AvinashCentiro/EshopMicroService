
namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Category,string Description,string ImageFile,decimal Price)
    :ICommand<CreateProductResult>;
    //these records are nothing but class with mentioned properties. 
    public record CreateProductResult(Guid Id);
    
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand,CreateProductResult>
    {
        //select I/F and  alt+Enter to implement missing functions 
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            //In Marten you can think that a session is a transactional unit of work that interacts with the database.
            //So that means we should use one of the session when interacting the PostgreSQL database using the Marten.
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //save to Db
            //return result

            return new CreateProductResult(product.Id);
        }
    }
}
