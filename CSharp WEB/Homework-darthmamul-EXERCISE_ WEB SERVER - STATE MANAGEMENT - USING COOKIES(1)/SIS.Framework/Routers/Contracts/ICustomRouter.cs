namespace SIS.Framework.Routers.Contracts
{
    using SIS.HTTP.Requests;
    using SIS.WebServer.Api;

    public interface ICustomRouter : IHttpRequestHandler
    {
        bool ContainsMapping(IHttpRequest httpRequest)
    }
}
