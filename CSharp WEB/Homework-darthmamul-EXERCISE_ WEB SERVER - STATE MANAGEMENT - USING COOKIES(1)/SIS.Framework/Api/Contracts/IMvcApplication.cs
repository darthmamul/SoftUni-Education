namespace SIS.Framework.Api.Contracts
{
    using SIS.Framework.Services.Contracts;

    public interface IMvcApplication
    {
        void Configure();

        void ConfigureServices(IDependencyContainer dependencyContainer);
    }
}
