using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.Configuration;
using DXSample.PersistentClasses;

namespace DXSample.DBUpdater {
    static class Program {
        static void Main(string[] args) {
            IDataLayer dal = XpoDefault.GetDataLayer(ConfigurationManager.ConnectionStrings["XpoConnection"].ConnectionString,
                AutoCreateOption.DatabaseAndSchema);
            UnitOfWork uow = new UnitOfWork(dal);
            uow.UpdateSchema(typeof(Customer).Assembly);
            uow.CreateObjectTypeRecords(typeof(Customer).Assembly);
            uow.Delete(new XPCollection<Customer>(uow));
            uow.Delete(new XPCollection<Order>(uow));
            uow.CommitChanges();
            uow.PurgeDeletedObjects();
            Customer john = new Customer(uow) { Name = "John", Age = 27 };
            Customer bob = new Customer(uow) { Name = "Bob", Age = 31 };
            new Order(uow) { OrderName = "Chai", OrderDate = new DateTime(2011, 1, 7), Customer = john };
            new Order(uow) { OrderName = "Chang", OrderDate = new DateTime(2011, 1, 8), Customer = john };
            new Order(uow) { OrderName = "Queso Caprale", OrderDate = new DateTime(2011, 1, 9), Customer = bob };
            uow.CommitChanges();
        }
    }
}