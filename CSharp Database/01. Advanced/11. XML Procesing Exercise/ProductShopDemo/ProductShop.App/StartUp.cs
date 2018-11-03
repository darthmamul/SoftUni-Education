using AutoMapper;
using ProductShop.App.Dto;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using DataAnotations = System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml.Serialization;
using ProductShop.Data;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using ProductShop.Dtos;

namespace ProductShop.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            InitializeDatabase();

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            var mapper = configuration.CreateMapper();

            SeedUsers(mapper);
            SeedProducts(mapper);
            SeedCategories(mapper);
            SeedCategoryProducts();
            ProductsInRange(mapper);
            SoldProducts();
            CategoriesByProductsCount();
            //UsersAndProducts();
        }

        //private static void UsersAndProducts()
        //{
        //    var context = new ProductShopContext();
        //    var users = new UsersDto()
        //    {
        //        Count = context.Users.Count(),
        //        UserSoldProducts = context.Users.Select(u => new UserDto
        //        {
        //            FirstName = u.FirstName,
        //            LastName = u.LastName,
        //            Age = u.Age,
        //            SoldProducts = u.SoldProducts.Select(s => new SoldProductsCount
        //            {
        //                Count = u.SoldProducts.Count(),
        //                Products = u.SoldProducts.Select(p => new soldProductsDto()
        //                {
        //                    Name = p.Name,
        //                    Price = p.Price
        //                }).ToArray()
        //            })
        //        })
        //        .OrderByDescending(u => u.SoldProducts.ProductsCount)
        //        .ThenBy(u => u.LastName).ToArray()
        //    };

        //    var serializer = new XmlSerializer(typeof(UsersDto), new XmlRootAttribute("users"));

        //    using (var writer = new StreamWriter(@"..\..\XML\users-and-products.xml"))
        //    {
        //        serializer.Serialize(writer, users, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
        //    }
        //}

        private static void CategoriesByProductsCount()
        {
            var context = new ProductShopContext();

            var categories = context.Categories
                .Include(e => e.CategoryProducts)
                .Select(e => new CategoryExportDto()
                {
                    Name = e.Name,
                    productCount = e.CategoryProducts.Count(),
                    AveragePrice = e.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = e.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(x => x.productCount)
                .ToList();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(List<CategoryExportDto>), new XmlRootAttribute("categories"));

            FileStream fs = new FileStream("categories-by-products.xml", FileMode.Create);
            serializer.Serialize(fs, categories, xmlNamespaces);
            fs.Close(); 
        }

        private static void SoldProducts()
        {
            var context = new ProductShopContext();
            var usersProduct = context.Users.Include(e => e.SoldProducts)
                .Where(x => x.SoldProducts.Count > 0)
                .Select(e => new SellerDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    SoldProducts = e.SoldProducts.Select(d => new soldProductsDto
                    {
                        Name = d.Name,
                        Price = d.Price
                    }).ToList()
                }).ToList();
            Console.WriteLine();
            XmlSerializer serializer = new XmlSerializer(typeof(List<SellerDto>), new XmlRootAttribute("users"));

            FileStream fs = new FileStream("user-sold-products.xml", FileMode.Create);
            serializer.Serialize(fs, usersProduct);
            fs.Close();
        }

        private static void ProductsInRange(IMapper mapper)
        {
            var context = new ProductShopContext();
            var products = context.Products.Where(e => e.Price >= 1000 && e.Price <= 2000 && e.BuyerId != null)
                .Select(x => new ExportProductDto
                {
                    Name = x.Name,
                    Price = x.Price.ToString(),
                    Buyer = x.Buyer.FirstName ?? " " + " " + x.Buyer.LastName ?? " "
                }).OrderBy(x => x.Price).ToList();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportProductDto>), new XmlRootAttribute("products"));

            FileStream fs = new FileStream("product-in-range.xml", FileMode.Create);
            serializer.Serialize(fs, products);
            fs.Close();
        }

        private static void SeedCategoryProducts()
        {
            var context = new ProductShopContext();
            var productKeys = context.Products.Select(x => x.Id).ToArray();
            var categoryKeys = context.Categories.Select(x => x.Id).ToArray();

            var random = new Random();
            var productCategories = new List<CategoryProduct>();

            for (int i = 0; i < productKeys.Length; i++)
            {
                var productCategory = new CategoryProduct()
                {
                    ProductId = productKeys[i],
                    CategoryId = categoryKeys[random.Next(0, categoryKeys.Length)]
                };
                productCategories.Add(productCategory);
            }

            context.CategoryProducts.AddRange(productCategories);
            context.SaveChanges();
            context.Dispose();
        }

        private static void SeedCategories(IMapper mapper)
        {
            var categoriesListDto = new List<CategoryDto>();
            var categories = new List<Category>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<CategoryDto>), new XmlRootAttribute("categories"));
            using (var reader = new StreamReader(@"..\..\XML\categories.xml"))
            {
                categoriesListDto = (List<CategoryDto>)serializer.Deserialize(reader);
            }

            foreach (var item in categoriesListDto)
            {
                var category = mapper.Map<Category>(item);
                categories.Add(category);
            }

            var context = new ProductShopContext();
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void SeedProducts(IMapper mapper)
        {
            var productListDto = new List<ProductDto>();
            var products = new List<Product>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ProductDto>), new XmlRootAttribute("products"));
            using (var reader = new StreamReader(@"..\..\XML\products.xml"))
            {
                productListDto = (List<ProductDto>)serializer.Deserialize(reader);
            }

            foreach (var p in productListDto)
            {
                var product = mapper.Map<Product>(p);
                products.Add(product);
            }

            var context = new ProductShopContext();

            var usersIds = context.Users.Select(x => x.Id).ToList();
            var random = new Random();

            for (int i = 0; i < products.Count; i++)
            {
                var buyerId = usersIds[random.Next(0, 35)];
                var sellerId = usersIds[random.Next(35, usersIds.Count)];

                if (i % 4 == 0)
                {
                    products[i].SellerId = sellerId;
                    continue;
                }
                products[i].SellerId = sellerId;
                products[i].BuyerId = buyerId;
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void SeedUsers(IMapper mapper)
        {
            var usersListDto = new List<UserDto>();
            var users = new List<User>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<UserDto>), new XmlRootAttribute("users"));
            using (var reader = new StreamReader(@"..\..\XML\users.xml"))
            {
                usersListDto = (List<UserDto>)serializer.Deserialize(reader);
            }

            foreach (var item in usersListDto)
            {
                var user = mapper.Map<User>(item);
                users.Add(user);
            }

            var context = new ProductShopContext();
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void InitializeDatabase()
        {
            var context = new ProductShopContext();

            using (context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Console.WriteLine("Database is initialized");
            }
        }
    }
}
