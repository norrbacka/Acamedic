namespace Domain
{
    public class Models
    {
        public abstract record BaseModel(Guid Id);
        public record Customer(Guid Id, string Name, Cart Cart) : BaseModel(Id);
        public record Cart(Guid Id, Item[] Items) : BaseModel(Id);
        public record Item(Guid Id, decimal Price, int Quantity, string Name) : BaseModel(Id)
        {
            public decimal TotalAmount => Price * Quantity;
        }
    }
}