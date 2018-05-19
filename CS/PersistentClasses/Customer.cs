using DevExpress.Xpo;

namespace DXSample.PersistentClasses {
    public class Customer :XPObject{
        public Customer(Session session) : base(session) { }

        private string fName;
        public string Name {
            get { return fName; }
            set { SetPropertyValue<string>("Name", ref fName, value); }
        }

        private int fAge;
        public int Age {
            get { return fAge; }
            set { SetPropertyValue<int>("Age", ref fAge, value); }
        }

        [Association("Customer-Orders")]
        public XPCollection<Order> Orders { get { return GetCollection<Order>("Orders"); } }
    }
}