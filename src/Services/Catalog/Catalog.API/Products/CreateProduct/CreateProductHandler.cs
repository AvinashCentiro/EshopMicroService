using BuildingBlocks.CQRS;


namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Category,string Description,string ImageFile,decimal Price)
    :ICommand<CreateProductResult>;
    //these records are nothing but class with mentioned properties. 
    public record CreateProductResult(Guid Id);
    
    internal class CreateProductCommandHandler  : ICommandHandler<CreateProductCommand,CreateProductResult>
    {
        //select I/F and  alt+Enter to implement missing functions 
        public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
