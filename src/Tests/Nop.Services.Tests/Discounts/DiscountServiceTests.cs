using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Discounts;
using Nop.Core.Infrastructure;
using Nop.Core.Plugins;
using Nop.Services.Common;
using Nop.Services.Discounts;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Tests;
using NUnit.Framework;
using Rhino.Mocks;

namespace Nop.Services.Tests.Discounts
{
    [TestFixture]
    public class DiscountServiceTests : ServiceTest
    {
        private IRepository<Discount> _discountRepo;
        private IRepository<DiscountRequirement> _discountRequirementRepo;
        private IRepository<DiscountUsageHistory> _discountUsageHistoryRepo;
        private IEventPublisher _eventPublisher;
        private IGenericAttributeService _genericAttributeService;
        private ILocalizationService _localizationService;
        private IDiscountService _discountService;
        private IStoreContext _storeContext;
        
        [SetUp]
        public new void SetUp()
        {
            _discountRepo = MockRepository.GenerateMock<IRepository<Discount>>();
            var discount1 = TestsData.GetDiscount;
            discount1.EndDateUtc = null;

            var discount2 = TestsData.GetDiscount;
            discount1.EndDateUtc = null;

            _discountRepo.Expect(x => x.Table).Return(new List<Discount> { discount1, discount2 }.AsQueryable());

            _eventPublisher = MockRepository.GenerateMock<IEventPublisher>();
            _eventPublisher.Expect(x => x.Publish(Arg<object>.Is.Anything));

            _storeContext = MockRepository.GenerateMock<IStoreContext>();

            var cacheManager = new NopNullCache();
            _discountRequirementRepo = MockRepository.GenerateMock<IRepository<DiscountRequirement>>();
            _discountUsageHistoryRepo = MockRepository.GenerateMock<IRepository<DiscountUsageHistory>>();
            var pluginFinder = new PluginFinder();
            _genericAttributeService = MockRepository.GenerateMock<IGenericAttributeService>();
            _localizationService = MockRepository.GenerateMock<ILocalizationService>();
            _discountService = new DiscountService(cacheManager, _discountRepo, _discountRequirementRepo,
                _discountUsageHistoryRepo, _storeContext, _genericAttributeService, 
                _localizationService, pluginFinder, _eventPublisher);
        }

        [Test]
        public void Can_get_all_discount()
        {
            var discounts = _discountService.GetAllDiscounts(null);
            discounts.ShouldNotBeNull();
            discounts.Any().ShouldBeTrue();
        }

        [Test]
        public void Can_load_discountRequirementRules()
        {
            var rules = _discountService.LoadAllDiscountRequirementRules();
            rules.ShouldNotBeNull();
            rules.Any().ShouldBeTrue();
        }

        [Test]
        public void Can_load_discountRequirementRuleBySystemKeyword()
        {
            var rule = _discountService.LoadDiscountRequirementRuleBySystemName("TestDiscountRequirementRule");
            rule.ShouldNotBeNull();
        }

        [Test]
        public void Should_accept_valid_discount_code()
        {
            var discount = TestsData.GetDiscount;
            discount.CouponCode = "CouponCode 1";
            discount.EndDateUtc = null;

            var customer = TestsData.GetCustomer();

            _genericAttributeService.Expect(x => x.GetAttributesForEntity(customer.Id, "Customer"))
                .Return(new List<GenericAttribute> {TestsData.CreateGenericAttribute(customer.Id, "CouponCode 1")});

            //UNDONE: little workaround here
            //we have to register "nop_cache_static" cache manager (null manager) from DependencyRegistrar.cs
            //because DiscountService right now dynamically Resolve<ICacheManager>("nop_cache_static")
            //we cannot inject it because DiscountService already has "per-request" cache manager injected 
            EngineContext.Initialize(false);
            //EngineContext.Current.ContainerManager.Expect(x => x.Resolve<ICacheManager>("nop_cache_static")).Return(new NopNullCache());
            
            _discountService.ValidateDiscount(discount, customer).IsValid.ShouldEqual(true);
        }


        [Test]
        public void Should_not_accept_wrong_discount_code()
        {
            var discount = TestsData.GetDiscount;
            discount.CouponCode = "CouponCode 1";
            discount.EndDateUtc = null;

            var customer = TestsData.GetCustomer();

            _genericAttributeService.Expect(x => x.GetAttributesForEntity(customer.Id, "Customer"))
                .Return(new List<GenericAttribute> {TestsData.CreateGenericAttribute(customer.Id, "CouponCode 2")});
            _discountService.ValidateDiscount(discount, customer).IsValid.ShouldEqual(false);
        }

        [Test]
        public void Can_validate_discount_dateRange()
        {
            var discount = TestsData.GetDiscount;
            discount.StartDateUtc = DateTime.UtcNow.AddDays(-1);
            discount.EndDateUtc = DateTime.UtcNow.AddDays(1);
            discount.RequiresCouponCode = false;

            var customer = TestsData.GetCustomer();

            _discountService.ValidateDiscount(discount, customer).IsValid.ShouldEqual(true);

            discount.StartDateUtc = DateTime.UtcNow.AddDays(1);
            _discountService.ValidateDiscount(discount, customer).IsValid.ShouldEqual(false);
        }
    }
}
