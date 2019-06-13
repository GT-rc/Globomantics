using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobomanticsProductCatalog.Data
{
    public static class SeedData
    {
        public static void Execute(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(CreateCSharpCategory(context));
                context.Categories.Add(CreateSciFiCategory(context));
                context.Categories.Add(CreateAzureCategory(context));

                context.SaveChanges();
            }
        }

        private static Category CreateAzureCategory(AppDbContext context)
        {
            var category = new Category
            {
                Name = "Microsoft Azure"
            };
            category.Products.Add(new Product
            {
                Name = "Microsoft Azure Basics",
                Description = "Suspendisse feugiat, libero vitae fermentum venenatis, lacus nulla vehicula lectus, sed tincidunt quam quam vitae tortor. Aliquam ultrices tempus finibus. Mauris sed imperdiet diam. Nam ornare, eros et porta euismod, purus odio mattis sem, in condimentum est turpis tincidunt purus.",
                Price = 9.99m
            });
            category.Products.Add(new Product
            {
                Name = "Intermediate Microsoft Azure",
                Description = "Fusce at massa vehicula, euismod arcu et, tempor risus. Donec hendrerit, erat imperdiet vulputate eleifend, felis est pharetra purus, a tempor purus odio et neque. Integer dictum velit est.",
                Price = 22.50m
            });
            category.Products.Add(new Product
            {
                Name = "Microsoft Azure for Non-Developers",
                Description = "Etiam commodo vel eros sit amet vulputate. Donec faucibus turpis eros, id commodo eros commodo ut. Morbi faucibus placerat augue vel pharetra. ",
                Price = 9.99m
            });

            return category;
        }

        private static Category CreateSciFiCategory(AppDbContext context)
        {
            var category = new Category
            {
                Name = "Science Fiction"
            };
            category.Products.Add(new Product
            {
                Name = "Aliens in Space",
                Description = "Suspendisse feugiat, libero vitae fermentum venenatis, lacus nulla vehicula lectus, sed tincidunt quam quam vitae tortor. Aliquam ultrices tempus finibus. Mauris sed imperdiet diam. Nam ornare, eros et porta euismod, purus odio mattis sem, in condimentum est turpis tincidunt purus.",
                Price = 14.99m
            });
            category.Products.Add(new Product
            {
                Name = "Aliens on a Plane!",
                Description = "Fusce at massa vehicula, euismod arcu et, tempor risus. Donec hendrerit, erat imperdiet vulputate eleifend, felis est pharetra purus, a tempor purus odio et neque. Integer dictum velit est.",
                Price = 22.50m
            });
            category.Products.Add(new Product
            {
                Name = "Build Your Own Starship Framework",
                Description = "Etiam commodo vel eros sit amet vulputate. Donec faucibus turpis eros, id commodo eros commodo ut. Morbi faucibus placerat augue vel pharetra. ",
                Price = 37.00m
            });

            return category;
        }

        private static Category CreateCSharpCategory(AppDbContext context)
        {
            var category = new Category
            {
                Name = "C# Programming"
            };
            category.Products.Add(new Product
            {
                Name = "Mastering C#",
                Description = "Suspendisse feugiat, libero vitae fermentum venenatis, lacus nulla vehicula lectus, sed tincidunt quam quam vitae tortor. Aliquam ultrices tempus finibus. Mauris sed imperdiet diam. Nam ornare, eros et porta euismod, purus odio mattis sem, in condimentum est turpis tincidunt purus.",
                Price = 29.99m
            });
            category.Products.Add(new Product
            {
                Name = "Improving Your C#",
                Description = "Fusce at massa vehicula, euismod arcu et, tempor risus. Donec hendrerit, erat imperdiet vulputate eleifend, felis est pharetra purus, a tempor purus odio et neque. Integer dictum velit est.",
                Price = 15.50m
            });
            category.Products.Add(new Product
            {
                Name = "Build Your Own Application Framework",
                Description = "Etiam commodo vel eros sit amet vulputate. Donec faucibus turpis eros, id commodo eros commodo ut. Morbi faucibus placerat augue vel pharetra. ",
                Price = 99.99m
            });

            return category;
        }
    }
}
