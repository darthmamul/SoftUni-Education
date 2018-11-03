﻿namespace IRunesWebApp.Controllers
{
    using System;
    using System.Linq;
    using IRunesWebApp.Data;
    using IRunesWebApp.Models;
    using IRunesWebApp.Services.Contracts;
    using IRunesWebApp.ViewModels;
    using Services;
    using SIS.Framework.ActionsResults.Base;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Methods;
    using SIS.Framework.Controllers;
    using SIS.Framework.Security;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.WebServer.Results;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Login() => this.View();
     
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid.HasValue || !ModelState.IsValid.Value)
            {
                return RedirectToAction("/users/login");
            }

            var userExists = this.usersService.ExistsByUsernameAndPassword(model.Username, model.Password);

            if (!userExists)
            {
                return RedirectToAction("/users/login");
            }

            this.SignIn(new IdentityUser {Username = model.Username, Password = model.Password });

            return this.RedirectToAction("/home/index");
        }

        [Authorize]
        public IActionResult Register() => this.View();

        //public IHttpResponse PostRegister(IHttpRequest request)
        //{
        //    var userName = request.FormData["username"].ToString().Trim();
        //    var password = request.FormData["password"].ToString();
        //    var confirmPassword = request.FormData["confirmPassword"].ToString();

        //    // Validate
        //    //if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4)
        //    //{
        //    //    return new BadRequestResult("Please provide valid username with length of 4 or more characters.");
        //    //}

        //    //if (this.Context.Users.Any(x => x.Username == userName))
        //    //{
        //    //    return new BadRequestResult("User with the same name already exists.");
        //    //}

        //    //if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
        //    //{
        //    //    return new BadRequestResult("Please provide password of length 6 or more.");
        //    //}

        //    if (password != confirmPassword)
        //    {
        //        return new BadRequestResult(
        //            "Passwords do not match.",
        //            HttpResponseStatusCode.SeeOther);
        //    }

        //    // Hash password
        //    var hashedPassword = this.hashService.Hash(password);

        //    // Create user
        //    var user = new User
        //    {
        //        Username = userName,
        //        HashedPassword = hashedPassword,
        //    };
        //    this.Context.Users.Add(user);

        //    try
        //    {
        //        this.Context.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Log error
        //        return new BadRequestResult(
        //            e.Message,
        //            HttpResponseStatusCode.InternalServerError);
        //    }

        //    var response = new RedirectResult("/");
        //    this.SignInUser(userName, response, request);

        //    // Redirect
        //    return response;
        //}


    }
}