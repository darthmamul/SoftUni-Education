namespace ProductShop.App
{
    using AutoMapper;

    using System;
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System.IO;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();

            var context = new ProductShopContext();

            //--ADD USERS--
            //var jsonString = File.ReadAllText("../../../Json/users.json");

            //var deserializedUsers = JsonConvert.DeserializeObject<User[]>(jsonString);

            //List<User> users = new List<User>();

            //foreach (var user in deserializedUsers)
            //{
            //    if (IsValid(user))
            //    {
            //        users.Add(user);
            //    }
            //}

            //context.Users.AddRange(users);
            //context.SaveChanges();
            //----------------------

            //--ADD PRODUCTS--
            //var jsonString = File.ReadAllText("../../../Json/products.json");

            //var deserializedProducts = JsonConvert.DeserializeObject<Product[]>(jsonString);

            //List<Product> products = new List<Product>();

            //foreach (var product in deserializedProducts)
            //{
            //    if (!IsValid(product))
            //    {
            //        continue;
            //    }

            //    var sellerId = new Random().Next(1, 35);
            //    var buyerId = new Random().Next(35, 57);

            //    var random = new Random().Next(1, 4);

            //    product.SellerId = sellerId;
            //    product.BuyerId = buyerId;

            //    if (random == 3)
            //    {
            //        product.BuyerId = null;
            //    }

            //    products.Add(product);
            //}

            //context.Products.AddRange(products);
            //context.SaveChanges();
            //----------------------

            //--ADD CATEGORIES--
            //var jsonString = File.ReadAllText("../../../Json/categories.json");

            //var deserializedCategories = JsonConvert.DeserializeObject<Category[]>(jsonString);

            //List<Category> categories = new List<Category>();

            //foreach (var category in deserializedCategories)
            //{
            //    if (!IsValid(category))
            //    {
            //        continue;
            //    }

            //    categories.Add(category);
            //}

            //context.Categories.AddRange(categories);
            //context.SaveChanges();
            //----------------------

            //--RANDOMLY GENERATE CATEGORIES--
            //var categoryProducts = new List<CategoryProduct>():

            //for (int productId = 1; productId <= 200; productId++)
            //{
            //    var categoryId = new Random().Next(1, 12);

            //    var categoryProduct = new CategoryProduct
            //    {
            //        CategoryId = categoryId,
            //        ProductId = productId
            //    };

            //    categoryProducts.Add(categoryProduct);
            //}

            //context.CategoryProducts.AddRange(categoryProducts);
            //context.SaveChanges();
            //----------------------

            //var products = context.Products
            //    .Where(x => x.Price >= 500 && x.Price <= 1000)
            //    .OrderBy(x => x.Price)
            //    .Select(s => new
            //    {
            //        name = s.Name,
            //        price = s.Price,
            //        seller = s.Seller.FirstName + " " + s.Seller.LastName ?? s.Seller.LastName
            //    })
            //    .ToArray();

            //var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);

            //File.WriteAllText("../../../Json/products-in-range.json", jsonProducts);
            //-----------------

            //--02--
            //var users = context.Users
            //    .Where(x => x.ProductsSold.Count >= 1 && x.ProductsSold.Any(s => s.Buyer != null))
            //    .OrderBy(l => l.LastName)
            //    .ThenBy(x => x.FirstName)
            //    .Select(s => new
            //    {
            //        firstName = s.FirstName,
            //        lastName = s.LastName,
            //        soldProducts = s.ProductsSold.Where(x => x.Buyer != null)
            //        .Select(v => new
            //        {
            //            name = v.Name,
            //            price = v.Price,
            //            buyerFirstName = v.Buyer.FirstName,
            //            buyerLastname = v.Buyer.LastName
            //        }).ToArray()
            //    }).ToArray();

            //var jsonProducts = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,
            //    NullValueHandling = NullValueHandling.Ignore
            //});

            //File.WriteAllText("../../../Json/users-sold-products.json", jsonProducts);

            //--03.CATEGORIES BY PRODUCTS COUNT--
            //var products = context.Categories
            //    .Select(x => new
            //    {
            //        category = x.Name,
            //        productsCount = x.CategoryProducts.Count(),
            //        averagePrice = x.CategoryProducts.Sum(s => s.Product.Price) / x.CategoryProducts.Count(),
            //        totalRevenue = x.CategoryProducts.Sum(s => s.Product.Price)
            //    })
            //    .OrderByDescending(x => x.productsCount)
            //    .ToArray();

            //var jsonProducts = JsonConvert.SerializeObject(products, new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,
            //    NullValueHandling = NullValueHandling.Ignore
            //});

            //File.WriteAllText("../../../Json/categories-by-products.json", jsonProducts);
            //-----------------------

            var users = new
            {
                usersCount = context.Users.Count(),
                users = context.Users
                .OrderByDescending(x => x.ProductsSold.Count)
                .ThenBy(l => l.LastName)
                .Where(x => x.ProductsSold.Count >= 1 && x.ProductsSold.Any(s => s.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count,
                        products = x.ProductsSold.Select(s => new
                        {
                            name = s.Name,
                            price = s.Price
                        }).ToArray()
                    }
                }).ToArray()
            };

            var jsonProducts = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("../../../Json/users-and-products.json", jsonProducts);
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
