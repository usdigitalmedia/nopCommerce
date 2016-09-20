using Nop.Tests;
using NUnit.Framework;

namespace Nop.Data.Tests.Shipping
{
    [TestFixture]
    public class ShipmentItemPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_shipmentItem()
        {
            var shipmentItem = TestsData.GetShipmentItem;
            shipmentItem.Shipment = TestsData.GetShipment;
            shipmentItem.Shipment.Order = TestsData.GetOrder;

            var fromDb = SaveAndLoadEntity(shipmentItem);
            fromDb.ShouldNotBeNull();
            fromDb.Shipment.ShouldNotBeNull();
            fromDb.OrderItemId.ShouldEqual(2);
            fromDb.Quantity.ShouldEqual(3);
            fromDb.WarehouseId.ShouldEqual(4);
        }
    }
}