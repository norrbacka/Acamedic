using static Domain.Models;

namespace Domain.Services
{
    public class Interfaces
    {
        public interface IBaseStore<IModel, TCreateCommand> 
            where IModel : BaseModel<TCreateCommand>
            where TCreateCommand : CreateCommand
        {
            Task<IModel> GetById(Guid id);
            Task Delete(IModel model);
            Task<Guid> Create(TCreateCommand cmd);
            Task Update(IModel model);
        }
        public interface ICustomerStore : IBaseStore<Customer, CreateCustomerCommand> { }
        public interface IItemStore : IBaseStore<Item, CreateItemCommand> { }
    }
}