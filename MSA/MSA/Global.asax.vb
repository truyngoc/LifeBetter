Imports System.Web.Optimization
Imports MSA.INFO
Imports MSA.COMMON
Imports MSA.DAO
Imports System.Globalization
Imports System.Threading

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        'Application("MSA_CONFIG") = Singleton(Of MSA_Caching_DAO).Inst.GetConfigToCache()
    End Sub

    Protected Sub Application_BeginRequest(sender As Object, e As EventArgs)
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US")
    End Sub

End Class