using Nop.Tests;
using NUnit.Framework;

namespace Nop.Data.Tests.Catalog
{
    [TestFixture]
    public class ProductTagPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_productTag()
        {
            var productTag = TestsData.GetProductTag;

            var fromDb = SaveAndLoadEntity(productTag);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("Name 1");
        }
    }
}