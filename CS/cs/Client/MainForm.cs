using System;
using System.Windows.Forms;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.Data.Filtering;

namespace DXSample.Client {
    public partial class MainForm :Form {
        public MainForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                uow.CommitChanges();
            } catch (LockingException) {
                MessageBox.Show(this, "Data was modified by another user. Please reload data.", 
                    "Dx Sample", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            uow.ReloadChangedObjects();
        }

        private void dataGridView2_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e) {
            e.Row.SetValues(null, DateTime.Now);
        }
    }
}
