Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DXSample.DataStore
Imports System.Windows.Forms
Imports DXSample.PersistentClasses
Imports DevExpress.Xpo.DB

Namespace DXSample.Client
	Friend NotInheritable Class Program
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			InitializeDataLayer()
			DesignTimeWorkaround.Register() ' this line can be removed from the release version
			Application.Run(New MainForm())
		End Sub

		Private Shared Sub InitializeDataLayer()
			XpoDefault.DataLayer = New SimpleDataLayer(New DataCacheNode(New CachingWCFServiceDataStore()))
		End Sub
	End Class
End Namespace