namespace Domain.Services
{
    public class Interfaces
    {
        public interface IBaseStore<IModel> where IModel : Models.BaseModel
        {
            Task<IModel> GetById(Guid id);
            Task Delete(IModel model);
            Task Create(IModel model);
            Task Update(IModel model);
        }
        public interface ICustomerStore : IBaseStore<Models.Customer> { }
        public interface ICartStore : IBaseStore<Models.Cart> { }
        public interface IItemStore : IBaseStore<Models.Item> { }
    }
}