Visual Studio ha agregado las dependencias conjunto completo de para ASP.NET Web API 2 al proyecto 'WebPay'. 

El archivo Global.asax.cs del proyecto requiere cambios adicionales para habilitar ASP.NET Web API.

1. Agregue las siguientes referencias de nombres de espacios:

    using System.Web.Http;
    using System.Web.Routing;

2. Si el código no tiene ya definido un método Application_Start, agregue el siguiente método:

    protected void Application_Start()
    {
    }

3. Agregue las siguientes líneas al comienzo del método Application_Start:

    GlobalConfiguration.Configure(WebApiConfig.Register);

