using System;
using System.Threading.Tasks;
using Domain;
using MemoryDatabase;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public async Task Prove_that_base_store_works()
        {
            var item = new Models.Item(Guid.NewGuid(), 100, 1, "Test");
            await Stores.Items.Create(item);
            var itemFetched = await Stores.Items.GetById(item.Id);
            Assert.AreEqual(item, itemFetched);

            var updated = itemFetched with
            {
                Quantity = 2
            };
            await Stores.Items.Update(updated);
            var updatedFetched = await Stores.Items.GetById(updated.Id);
            Assert.AreEqual(updated, updatedFetched);
            Assert.AreEqual(updated.Id, item.Id);

            await Stores.Items.Delete(updatedFetched);
            Assert.ThrowsAsync<InvalidOperationException>(() => Stores.Items.GetById(updatedFetched.Id));
        }        
    }
}