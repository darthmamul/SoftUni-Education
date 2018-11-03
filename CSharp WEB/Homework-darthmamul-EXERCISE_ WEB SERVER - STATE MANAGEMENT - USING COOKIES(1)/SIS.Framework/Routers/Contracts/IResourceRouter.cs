namespace SIS.Framework.Routers.Contracts
{
    using SIS.WebServer.Api;

    public interface IResourceRouter : IHttpRequestHandler
    {
        bool IsResourceRequest(string httpRequestPath);
    }
}
