using Nop.Tests;
using NUnit.Framework;

namespace Nop.Data.Tests.Discounts
{
    [TestFixture]
    public class DiscountRequirementPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_discountRequirement()
        {
            var discountRequirement = TestsData.GetDiscountRequirement;
            discountRequirement.Discount = TestsData.GetDiscount;

            var fromDb = SaveAndLoadEntity(discountRequirement);
            fromDb.ShouldNotBeNull();
            fromDb.DiscountRequirementRuleSystemName.ShouldEqual("BillingCountryIs");


            fromDb.Discount.ShouldNotBeNull();
            fromDb.Discount.Name.ShouldEqual("Discount 1");
        }
    }
}