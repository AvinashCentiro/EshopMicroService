using BuildingBlocks.CQRS;
using Catalog.API.Models;


namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Category,string Description,string ImageFile,decimal Price)
    :ICommand<CreateProductResult>;
    //these records are nothing but class with mentioned properties. 
    public record CreateProductResult(Guid Id);
    
    internal class CreateProductCommandHandler  : ICommandHandler<CreateProductCommand,CreateProductResult>
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
            //save to Db
            //return result

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
