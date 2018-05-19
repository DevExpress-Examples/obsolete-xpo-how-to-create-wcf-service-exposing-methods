using DevExpress.Xpo;
using System;

namespace DXSample.PersistentClasses {
    public class Order : XPObject{
        public Order(Session session) : base(session) { }

        private string fOrderName;
        public string OrderName {
            get { return fOrderName; }
            set { SetPropertyValue<string>("OrderName", ref fOrderName, value); }
        }

        private DateTime fOrderDate;
        public DateTime OrderDate {
            get { return fOrderDate; }
            set { SetPropertyValue<DateTime>("OrderDate", ref fOrderDate, value); }
        }

        private Customer fCustomer;
        [Association("Customer-Orders")]
        public Customer Customer {
            get { return fCustomer; }
            set { SetPropertyValue<Customer>("Customer", ref fCustomer, value); }
        }
    }
}