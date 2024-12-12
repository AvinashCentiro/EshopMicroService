namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;// A keyword that assigns the default value for the type. For string, the default value is null.
        // ! It indicates to the compiler that the property will not be null
        public List<string> Category { get; set; } = new();

        //Assigns an initial value to the property.It's equivalent to new List<string>()
        public string Description { get; set; } = default!;

        public string ImageFile { get; set; } = default!;

        public decimal Price { get; set; }
    }
}
