using Catalog.API.Models;

namespace Catalog.API.Products.UpdateProduct
{

    public record UpdateProductCommand(Guid Id,string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        :ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    internal class UpdateProductHandler(IDocumentSession session,ILogger<UpdateProductHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductHandler.Handle with command:{@command}",command);
            var product = await session.LoadAsync<Product>(command.Id,cancellationToken);
            //session.LoadAsync<Product> here we are expecting Product Info so adding Product here.
            //(command.Id,cancellationToken) this will retrieve single product

            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            product.Name=command.Name;
            product.Category=command.Category;
            product.Description=command.Description;
            product.ImageFile=command.ImageFile;
            product.Price=command.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }


        /* In this handle method, we basically use Martin's IDocumentSession in order to load the product by ID and
         apply the updates.If the product doesn't exist, it throws Exception product not found.
         After updating the product details, it saves the changes to the database.
        */
    }
}
