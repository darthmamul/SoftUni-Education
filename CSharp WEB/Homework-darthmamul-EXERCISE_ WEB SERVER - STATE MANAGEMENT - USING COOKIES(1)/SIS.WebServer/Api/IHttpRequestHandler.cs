namespace SIS.WebServer.Api
{
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;

    public interface IHttpRequestHandler
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}
