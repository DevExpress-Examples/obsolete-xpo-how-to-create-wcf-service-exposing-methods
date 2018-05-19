using System;
using DevExpress.Xpo;
using DXSample.DataStore;
using System.Windows.Forms;
using DXSample.PersistentClasses;
using DevExpress.Xpo.DB;

namespace DXSample.Client {
    static class Program {
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeDataLayer();
            DesignTimeWorkaround.Register(); // this line can be removed from the release version
            Application.Run(new MainForm());
        }

        static void InitializeDataLayer() {
            XpoDefault.DataLayer = new SimpleDataLayer(new DataCacheNode(new CachingWCFServiceDataStore()));
        }
    }
}