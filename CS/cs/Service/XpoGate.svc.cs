using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.ServiceModel;
using System.Configuration;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.Xpo.DB.Exceptions;
using System;

namespace DXSample.Service {
    public class XpoGate :IXpoGate {
        static ICacheToCacheCommunicationCore dataStore;

        static XpoGate() {
            string conn = ConfigurationManager.ConnectionStrings["XpoConnection"].ConnectionString;
            dataStore = new DataCacheRoot(XpoDefault.GetConnectionProvider(conn, AutoCreateOption.None));
        }
        
        #region IXpoGate Members

        DataCacheModificationResult IXpoGate.ModifyData(DataCacheCookie cookie, ModificationStatement[] dmlStatements) {
            try {
                return dataStore.ModifyData(cookie, dmlStatements);
            } catch (LockingException ex) {
                throw new FaultException<LockingException>(ex);
            }
        }

        DataCacheResult IXpoGate.NotifyDirtyTables(DataCacheCookie cookie, params string[] dirtyTablesNames) {
            return dataStore.NotifyDirtyTables(cookie, dirtyTablesNames);
        }

        DataCacheResult IXpoGate.ProcessCookie(DataCacheCookie cookie) {
            return dataStore.ProcessCookie(cookie);
        }

        DataCacheSelectDataResult IXpoGate.SelectData(DataCacheCookie cookie, SelectStatement[] selects) {
            return dataStore.SelectData(cookie, selects);
        }

        #endregion
    }
}
