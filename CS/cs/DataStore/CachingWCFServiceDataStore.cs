using System;
using DevExpress.Xpo.DB;
using System.Diagnostics;
using System.ServiceModel;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.Xpo.DB.Exceptions;
using System.ServiceModel.Channels;

namespace DXSample.DataStore {
    [DebuggerStepThrough]
    public partial class CachingWCFServiceDataStore :ClientBase<IXpoGate>, ICachedDataStore {

        public CachingWCFServiceDataStore() : base() { }
        public CachingWCFServiceDataStore(string endpointConfigurationName) : base(endpointConfigurationName) { }

        public CachingWCFServiceDataStore(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress) { }

        public CachingWCFServiceDataStore(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress) { }

        public CachingWCFServiceDataStore(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) { }

        static void PatchParameters(JoinNode[] statements) {
            foreach (JoinNode statement in statements)
                statement.Condition = CriteriaPatcher.Patch(statement.Condition);
        }

        #region ICacheToCacheCommunicationCore Members

        DataCacheModificationResult ICacheToCacheCommunicationCore.ModifyData(DataCacheCookie cookie, 
            ModificationStatement[] dmlStatements) {
            try {
                PatchParameters(dmlStatements);
                return Channel.ModifyData(cookie, dmlStatements);
            } catch (FaultException<LockingException> ex) {
                throw ex.Detail;
            }
        }

        DataCacheResult ICacheToCacheCommunicationCore.NotifyDirtyTables(DataCacheCookie cookie, params string[] dirtyTablesNames) {
            return Channel.NotifyDirtyTables(cookie, dirtyTablesNames);
        }

        DataCacheResult ICacheToCacheCommunicationCore.ProcessCookie(DataCacheCookie cookie) {
            return Channel.ProcessCookie(cookie);
        }

        DataCacheSelectDataResult ICacheToCacheCommunicationCore.SelectData(DataCacheCookie cookie, SelectStatement[] selects) {
            PatchParameters(selects);
            return Channel.SelectData(cookie, selects);
        }

        DataCacheUpdateSchemaResult ICacheToCacheCommunicationCore.UpdateSchema(DataCacheCookie cookie, DBTable[] tables, 
            bool dontCreateIfFirstTableNotExist) {
            throw new NotSupportedException("Database schema modifications not allowed");
        }

        #endregion

        #region IDataStore Members

        AutoCreateOption IDataStore.AutoCreateOption {
            get { return AutoCreateOption.SchemaAlreadyExists; }
        }

        ModificationResult IDataStore.ModifyData(params ModificationStatement[] dmlStatements) {
            try {
                return Channel.ModifyData(DataCacheCookie.Empty, dmlStatements).ModificationResult;
            } catch (FaultException<LockingException> ex) {
                throw ex.Detail;
            }
        }

        SelectedData IDataStore.SelectData(params SelectStatement[] selects) {
            return Channel.SelectData(DataCacheCookie.Empty, selects).SelectedData;
        }

        UpdateSchemaResult IDataStore.UpdateSchema(bool dontCreateIfFirstTableNotExist, params DBTable[] tables) {
            throw new NotSupportedException("Database schema modifications not allowed");
        }

        #endregion
    }
}
