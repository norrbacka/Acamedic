using Domain;
using static Domain.Services.Interfaces;

namespace MemoryDatabase
{
    public class Stores
    {
        public abstract class BaseStore<IModel> : IBaseStore<IModel> where IModel : Models.BaseModel
        {
            public static List<IModel> Db { get; set; } = new List<IModel>();
            public async Task Create(IModel model) => await Task.Run(() => Db.Add(model));
            public async Task Delete(IModel model) => await Task.Run(() => Db.Remove(model));
            public async Task<IModel> GetById(Guid id) => await Task.Run(() => Db.Single(x => x.Id == id));
            public async Task Update(IModel model) => await Task.Run(() => Db[Db.FindIndex(x => x.Id == model.Id)] = model);
        }

        public class CustomerStore : BaseStore<Models.Customer>, ICustomerStore { }
        public class CartStore : BaseStore<Models.Cart>, ICartStore { }
        public class ItemStore : BaseStore<Models.Item>, IItemStore { }
        
        public static CustomerStore Customers { get; set; } = new CustomerStore();
        public static CartStore Carts { get; set; } = new CartStore();
        public static ItemStore Items { get; set; } = new ItemStore();
    }
}