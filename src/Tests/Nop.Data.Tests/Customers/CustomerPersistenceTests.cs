using System;
using System.Linq;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Tests;
using NUnit.Framework;

namespace Nop.Data.Tests.Customers
{
    [TestFixture]
    public class CustomerPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_customer()
        {
            var customer = TestsData.GetCustomer();

            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();
            fromDb.Username.ShouldEqual("a@b.com");
            fromDb.Password.ShouldEqual("password");
            fromDb.PasswordFormat.ShouldEqual(PasswordFormat.Clear);
            fromDb.PasswordSalt.ShouldEqual("");
            fromDb.Email.ShouldEqual("a@b.com");
            fromDb.AdminComment.ShouldEqual("some comment here");
            fromDb.IsTaxExempt.ShouldEqual(true);
            fromDb.AffiliateId.ShouldEqual(1);
            fromDb.VendorId.ShouldEqual(2);
            fromDb.HasShoppingCartItems.ShouldEqual(true);
            fromDb.Active.ShouldEqual(true);
            fromDb.Deleted.ShouldEqual(false);
            fromDb.IsSystemAccount.ShouldEqual(true);
            fromDb.SystemName.ShouldEqual("SystemName 1");
            fromDb.LastIpAddress.ShouldEqual("192.168.1.1");
            fromDb.CreatedOnUtc.ShouldEqual(new DateTime(2010, 01, 01));
            fromDb.LastLoginDateUtc.ShouldEqual(new DateTime(2010, 01, 02));
            fromDb.LastActivityDateUtc.ShouldEqual(new DateTime(2010, 01, 02));
        }

        [Test]
        public void Can_save_and_load_customer_with_customerRoles()
        {
            var customer = TestsData.GetCustomer("Administrators");


            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();

            fromDb.CustomerRoles.ShouldNotBeNull();
            (fromDb.CustomerRoles.Count == 1).ShouldBeTrue();
            fromDb.CustomerRoles.First().Name.ShouldEqual("Administrators");
        }

        [Test]
        public void Can_save_and_load_customer_with_externalAuthenticationRecord()
        {
            var customer = TestsData.GetCustomer();
            customer.ExternalAuthenticationRecords.Add(TestsData.GetExternalAuthenticationRecord);

            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();

            fromDb.ExternalAuthenticationRecords.ShouldNotBeNull();
            (fromDb.ExternalAuthenticationRecords.Count == 1).ShouldBeTrue();
            fromDb.ExternalAuthenticationRecords.First().ExternalIdentifier.ShouldEqual("ExternalIdentifier 1");
        }


        [Test]
        public void Can_save_and_load_customer_with_address()
        {
            var customer = TestsData.GetCustomer();
            customer.Addresses.Add(TestsData.GetAddress);
            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();
            fromDb.Addresses.Count.ShouldEqual(1);
            fromDb.Addresses.First().FirstName.ShouldEqual("FirstName 1");
        }

        [Test]
        public void Can_set_default_billing_and_shipping_address()
        {
            var customer = TestsData.GetCustomer();

            var address = new Address { FirstName = "Billing", Country = TestsData.GetCountry, CreatedOnUtc = new DateTime(2010, 01, 01) };
            var address2 = new Address { FirstName = "Shipping", Country = TestsData.GetCountry, CreatedOnUtc = new DateTime(2010, 01, 01) };

            customer.Addresses.Add(address);
            customer.Addresses.Add(address2);

            customer.BillingAddress = address;
            customer.ShippingAddress = address2;

            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();
            fromDb.Addresses.Count.ShouldEqual(2);

            fromDb.BillingAddress.FirstName.ShouldEqual("Billing");
            fromDb.ShippingAddress.FirstName.ShouldEqual("Shipping");

            var addresses = fromDb.Addresses.ToList();

            fromDb.BillingAddress.ShouldBeTheSameAs(addresses[0]);
            fromDb.ShippingAddress.ShouldBeTheSameAs(addresses[1]);
        }

        [Test]
        public void Can_remove_a_customer_address()
        {
            var customer = TestsData.GetCustomer();
            var address = TestsData.GetAddress;
            customer.Addresses.Add(address);
            customer.BillingAddress = address;

            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();
            fromDb.Addresses.Count.ShouldEqual(1);
            fromDb.BillingAddress.ShouldNotBeNull();

            fromDb.RemoveAddress(address);

            context.SaveChanges();

            fromDb.Addresses.Count.ShouldEqual(0);
            fromDb.BillingAddress.ShouldBeNull();
        }
        
        [Test]
        public void Can_save_and_load_customer_with_shopping_cart()
        {
            var customer = TestsData.GetCustomer();
            
            var fromDb = SaveAndLoadEntity(customer);
            fromDb.ShouldNotBeNull();

            fromDb.ShoppingCartItems.ShouldNotBeNull();
            (fromDb.ShoppingCartItems.Count == 1).ShouldBeTrue();
            fromDb.ShoppingCartItems.First().AttributesXml.ShouldEqual("AttributesXml 1");
        }
    }
}
