namespace IRunesWebApp.Controllers
{
    using IRunesWebApp.ViewModels;
    using SIS.Framework.ActionsResults.Base;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Controllers;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var loginViewModel = new LoginViewModel
            {
                Username = "Pesho",
                Password = "123",
                NestedViewModels = new List<NestedViewModel>
                {
                    new NestedViewModel(){Count = 5, NestingLevel = 1 },
                    new NestedViewModel(){Count = 500, NestingLevel = 200 },
                },
            };

            this.ViewModel.Data["LoginViewModel"] = loginViewModel;

            return this.View();
        }
    }
}
