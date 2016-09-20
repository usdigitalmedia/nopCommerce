using System.Linq;
using Nop.Tests;
using NUnit.Framework;

namespace Nop.Data.Tests.Security
{
    [TestFixture]
    public class PermissionRecordPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_permissionRecord()
        {
            var permissionRecord = TestsData.GetPermissionRecord;

            var fromDb = SaveAndLoadEntity(permissionRecord);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("Name 1");
            fromDb.SystemName.ShouldEqual("SystemName 2");
            fromDb.Category.ShouldEqual("Category 4");
        }

        [Test]
        public void Can_save_and_load_permissionRecord_with_customerRoles()
        {
            var permissionRecord = TestsData.GetPermissionRecord;
            permissionRecord.CustomerRoles.Add(TestsData.GetCustomerRole("Administrators"));

            var fromDb = SaveAndLoadEntity(permissionRecord);
            fromDb.ShouldNotBeNull();

            fromDb.CustomerRoles.ShouldNotBeNull();
            (fromDb.CustomerRoles.Count == 1).ShouldBeTrue();
            fromDb.CustomerRoles.First().Name.ShouldEqual("Administrators");
        }
    }
}
