﻿namespace Forum.App.Factories
{
    using Contracts;
    using System;
    using System.Reflection;
    using System.Linq;

    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Type menuType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == menuName);

            if (menuType == null)
            {
                throw new ArgumentException($"{menuName} not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuName} is not an IMenu");
            }

            ParameterInfo[] ctorParams = menuType.GetConstructors().First().GetParameters();
            object[] arguments = new object[ctorParams.Length];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, arguments);

            return menu;
        }
    }
}
