using System.Linq;
using Nop.Tests;
using NUnit.Framework;

namespace Nop.Data.Tests.Shipping
{
    [TestFixture]
    public class ShippingMethodPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_shippingMethod()
        {
            var shippingMethod = TestsData.GetShippingMethod;

            var fromDb = SaveAndLoadEntity(shippingMethod);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("By train");
            fromDb.Description.ShouldEqual("Description 1");
            fromDb.DisplayOrder.ShouldEqual(1);
        }

        [Test]
        public void Can_save_and_load_shippingMethod_with_restriction()
        {
            var shippingMethod = TestsData.GetShippingMethod;
            shippingMethod.RestrictedCountries.Add(TestsData.GetCountry);

            var fromDb = SaveAndLoadEntity(shippingMethod);
            fromDb.ShouldNotBeNull();


            fromDb.RestrictedCountries.ShouldNotBeNull();
            (fromDb.RestrictedCountries.Count == 1).ShouldBeTrue();
            fromDb.RestrictedCountries.First().Name.ShouldEqual("United States");
        }
    }
}