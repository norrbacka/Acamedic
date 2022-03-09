
namespace Domain
{
    public class Models
    {
        public abstract record CreateCommand(Guid Id);

        public abstract record BaseModel<From> where From : CreateCommand
        {
            public Guid Id { get; protected set; }
            protected BaseModel() { }
            protected BaseModel(Guid id)
            {
                Id = id;
            }
            public BaseModel(From from) => Map(from);
            public abstract void Map(From from);
        }

        public record CreateCustomerCommand(string Name) : CreateCommand(Guid.NewGuid());
        public record Customer : BaseModel<CreateCustomerCommand>
        {
            public string Name { get; protected set; }    

            public override void Map(CreateCustomerCommand from)
            {
                Id = from.Id;
                Name = from.Name;
            }
        }

        public record CreateItemCommand(decimal Price, int Quantity, string Name) : CreateCommand(Guid.NewGuid());
        public record Item : BaseModel<CreateItemCommand>
        {
            public decimal Price { get; protected set; }
            public int Quantity { get; protected set; }
            public string Name { get; protected set; }
            public decimal TotalAmount => Price * Quantity;
            public override void Map(CreateItemCommand from)
            {
                Price = from.Price;
                Quantity = from.Quantity;
                Name = from.Name;
            }
        }
    }
}