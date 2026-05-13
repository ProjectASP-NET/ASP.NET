using D_DStore.Domain.Entities.BaseProduct;
using D_DStore.Domain.Entities.BaseProduct.Brand;
using D_DStore.Domain.Entities.Consumable;
using D_DStore.Domain.Entities.Liquid;
using D_DStore.Domain.Entities.Product;
using D_DStore.Domain.Entities.Vape;
using D_DStore.Domain.Enums;
using D_DStore.Domain.Entities.User;
using D_DStore.Domain.Entities.Order;
using D_DStore.Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;

namespace D_DStore.DataAccess.DB
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(ProductDbContext productContext, UserDbContext userContext, OrderDbContext orderContext)
        {
            await productContext.Database.MigrateAsync();
            await userContext.Database.MigrateAsync();
            await orderContext.Database.MigrateAsync();

            // 1. Роли
            if (!userContext.Roles.Any())
            {
                var roles = new List<RoleData>
                {
                    new RoleData
                    {
                        Name = "Admin",
                        Description = "Администратор с полными правами доступа"
                    },
                    new RoleData
                    {
                        Name = "User",
                        Description = "Обычный пользователь с ограниченными правами доступа"
                    },
                    new RoleData
                    {
                        Name = "Manager",
                        Description = "Менеджер с правами управления товарами и заказами"
                    }
                };
                await userContext.Roles.AddRangeAsync(roles);
                await userContext.SaveChangesAsync();
            }

            // 2. Пользователи
            if (!userContext.Users.Any())
            {
                var adminRole = await userContext.Roles.FirstAsync(r => r.Name == "Admin");
                var userRole = await userContext.Roles.FirstAsync(r => r.Name == "User");

                var users = new List<UserData>
                {
                    new UserData
                    {
                        NickName = "admin",
                        Email = "admin@ddliquid.com",
                        PasswordHash = "hashed_password_admin", // В реальном проекте используйте BCrypt или аналог
                        RoleId = adminRole.Id
                    },
                    new UserData
                    {
                        NickName = "testuser",
                        Email = "user@test.com",
                        PasswordHash = "hashed_password_user",
                        RoleId = userRole.Id
                    }
                };
                await userContext.Users.AddRangeAsync(users);
                await userContext.SaveChangesAsync();
            }

            // 3. Страны
            if (!await productContext.Countries.AnyAsync())
            {
                var countries = new List<CountryData>
                {
                    new CountryData { Name = "United States", Code = "US" },
                    new CountryData { Name = "United Kingdom", Code = "UK" },
                    new CountryData { Name = "China", Code = "CN" },
                    new CountryData { Name = "France", Code = "FR" },
                    new CountryData { Name = "Malaysia", Code = "MY" }
                };
                await productContext.Countries.AddRangeAsync(countries);
                await productContext.SaveChangesAsync();
            }

            // 4. Бренды
            if (!await productContext.Brands.AnyAsync())
            {
                var us = await productContext.Countries.FirstAsync(c => c.Code == "US");
                var uk = await productContext.Countries.FirstAsync(c => c.Code == "UK");
                var cn = await productContext.Countries.FirstAsync(c => c.Code == "CN");
                var my = await productContext.Countries.FirstAsync(c => c.Code == "MY");

                var brands = new List<BrandData>
                {
                    new BrandData { Name = "Elfbar", Description = "Популярный китайский бренд одноразок и жидкостей", CountryId = cn.Id },
                    new BrandData { Name = "Nasty Juice", Description = "Малайзийский бренд премиум жидкостей", CountryId = my.Id },
                    new BrandData { Name = "Voopoo", Description = "Китайский производитель девайсов", CountryId = cn.Id },
                    new BrandData { Name = "Geekvape", Description = "Защищённые моды и атомайзеры", CountryId = cn.Id },
                    new BrandData { Name = "Vampire Vape", Description = "Британский бренд классических жидкостей", CountryId = uk.Id }
                };
                await productContext.Brands.AddRangeAsync(brands);
                await productContext.SaveChangesAsync();
            }

            // 5. Категории
            if (!await productContext.Categories.AnyAsync())
            {
                var categories = new List<ProductCategoryData>
                {
                    new ProductCategoryData { Name = "Жидкости", Description = "Жидкости для вейпа", IconUrl = "icons/liquid.png" },
                    new ProductCategoryData { Name = "Девайсы", Description = "Вейпы и моды", IconUrl = "icons/vape.png" },
                    new ProductCategoryData { Name = "Расходники", Description = "Испарители, хлопок и т.д.", IconUrl = "icons/consumable.png" }
                };
                await productContext.Categories.AddRangeAsync(categories);
                await productContext.SaveChangesAsync();
            }

            // 6. Теги
            if (!await productContext.Tags.AnyAsync())
            {
                var tags = new List<ProductTagData>
                {
                    new ProductTagData { Name = "Новинка" },
                    new ProductTagData { Name = "Хит продаж" },
                    new ProductTagData { Name = "Солевой" },
                    new ProductTagData { Name = "На органике" },
                    new ProductTagData { Name = "Скидка" }
                };
                await productContext.Tags.AddRangeAsync(tags);
                await productContext.SaveChangesAsync();
            }

            // 7. Вкусы
            if (!await productContext.Flavors.AnyAsync())
            {
                var flavors = new List<FlavorData>
                {
                    new FlavorData { Name = "Mango" },
                    new FlavorData { Name = "Blueberry" },
                    new FlavorData { Name = "Ice" },
                    new FlavorData { Name = "Strawberry" },
                    new FlavorData { Name = "Watermelon" },
                    new FlavorData { Name = "Peach" },
                    new FlavorData { Name = "Grape" },
                    new FlavorData { Name = "Lemon" }
                };
                await productContext.Flavors.AddRangeAsync(flavors);
                await productContext.SaveChangesAsync();
            }

            // 8. Жидкости
            if (!await productContext.Liquids.AnyAsync())
            {
                var elfbar = await productContext.Brands.FirstAsync(b => b.Name == "Elfbar");
                var nasty = await productContext.Brands.FirstAsync(b => b.Name == "Nasty Juice");
                var vampire = await productContext.Brands.FirstAsync(b => b.Name == "Vampire Vape");

                var catLiquid = await productContext.Categories.FirstAsync(c => c.Name == "Жидкости");

                var fMango = await productContext.Flavors.FirstAsync(f => f.Name == "Mango");
                var fBlueberry = await productContext.Flavors.FirstAsync(f => f.Name == "Blueberry");
                var fIce = await productContext.Flavors.FirstAsync(f => f.Name == "Ice");
                var fStrawberry = await productContext.Flavors.FirstAsync(f => f.Name == "Strawberry");
                var fWatermelon = await productContext.Flavors.FirstAsync(f => f.Name == "Watermelon");
                var fPeach = await productContext.Flavors.FirstAsync(f => f.Name == "Peach");

                var tagHit = await productContext.Tags.FirstAsync(t => t.Name == "Хит продаж");
                var tagSalt = await productContext.Tags.FirstAsync(t => t.Name == "Солевой");
                var tagNew = await productContext.Tags.FirstAsync(t => t.Name == "Новинка");

                var liquids = new List<LiquidData>
                {
                    new LiquidData
                    {
                        Name = "Blueberry Ice",
                        Description = "Сочная черника с холодком",
                        Price = 12.99m,
                        StockQuantity = 50,
                        Volume = 30,
                        Nicotine = 20,
                        IceLevel = 3,
                        BrandId = elfbar.Id,
                        CategoryId = catLiquid.Id,
                        Flavors = new List<FlavorData> { fBlueberry, fIce },
                        Tags = new List<ProductTagData> { tagHit, tagSalt },
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "images/blueberry_ice.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new LiquidData
                    {
                        Name = "Mango Peach",
                        Description = "Спелое манго с персиком",
                        Price = 10.99m,
                        StockQuantity = 35,
                        Volume = 60,
                        Nicotine = 3,
                        IceLevel = 0,
                        BrandId = nasty.Id,
                        CategoryId = catLiquid.Id,
                        Flavors = new List<FlavorData> { fMango, fPeach },
                        Tags = new List<ProductTagData> { tagNew },
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "images/mango_peach.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new LiquidData
                    {
                        Name = "Heisenberg",
                        Description = "Культовый вкус — ягоды с анисом и холодком",
                        Price = 9.49m,
                        StockQuantity = 20,
                        Volume = 50,
                        Nicotine = 6,
                        IceLevel = 2,
                        BrandId = vampire.Id,
                        CategoryId = catLiquid.Id,
                        Flavors = new List<FlavorData> { fStrawberry, fWatermelon },
                        Tags = new List<ProductTagData> { tagHit },
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "images/heisenberg.png", IsMain = true, SortOrder = 1 }
                        }
                    }
                };
                await productContext.Liquids.AddRangeAsync(liquids);
                await productContext.SaveChangesAsync();
            }

            // 9. Вейпы
            if (!await productContext.Vapes.AnyAsync())
            {
                var voopoo = await productContext.Brands.FirstAsync(b => b.Name == "Voopoo");
                var geekvape = await productContext.Brands.FirstAsync(b => b.Name == "Geekvape");
                var catVape = await productContext.Categories.FirstAsync(c => c.Name == "Девайсы");
                var tagNew = await productContext.Tags.FirstAsync(t => t.Name == "Новинка");
                var tagHit = await productContext.Tags.FirstAsync(t => t.Name == "Хит продаж");

                var vapes = new List<VapeData>
                {
                    new VapeData
                    {
                        Name = "Drag 4",
                        Description = "Компактный мод с чипом Gene.TT2",
                        Price = 64.99m,
                        StockQuantity = 15,
                        BatteryCapacity = 3000,
                        MaxPower = 177,
                        Color = "Silver",
                        TankCapacity = 5.0m,
                        CoilResistance = 0.15m,
                        BrandId = voopoo.Id,
                        CategoryId = catVape.Id,
                        Tags = new List<ProductTagData> { tagHit },
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "images/drag4.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new VapeData
                    {
                        Name = "Aegis Legend 2",
                        Description = "Флагманский мод с защитой от воды и пыли",
                        Price = 79.99m,
                        StockQuantity = 10,
                        BatteryCapacity = 4000,
                        MaxPower = 200,
                        Color = "Black",
                        TankCapacity = 5.5m,
                        CoilResistance = 0.2m,
                        BrandId = geekvape.Id,
                        CategoryId = catVape.Id,
                        Tags = new List<ProductTagData> { tagNew },
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "images/aegis2.png", IsMain = true, SortOrder = 1 }
                        }
                    }
                };
                await productContext.Vapes.AddRangeAsync(vapes);
                await productContext.SaveChangesAsync();
            }

            // 10. Расходники
            if (!await productContext.Consumables.AnyAsync())
            {
                var geekvape = await productContext.Brands.FirstAsync(b => b.Name == "Geekvape");
                var catCons = await productContext.Categories.FirstAsync(c => c.Name == "Расходники");
                var tagNew = await productContext.Tags.FirstAsync(t => t.Name == "Новинка");

                var consumables = new List<ConsumableData>
                {
                    new ConsumableData
                    {
                        Name = "Coil Geekvape Z 0.2",
                        Description = "Испаритель 0.2 Ом для серии Aegis",
                        Price = 4.99m,
                        StockQuantity = 100,
                        BrandId = geekvape.Id,
                        CategoryId = catCons.Id,
                        Tags = new List<ProductTagData> { tagNew },
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "images/coil_z02.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new ConsumableData
                    {
                        Name = "Cotton Bacon Prime",
                        Description = "Органический хлопок для намоток",
                        Price = 6.49m,
                        StockQuantity = 60,
                        BrandId = geekvape.Id,
                        CategoryId = catCons.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "images/cotton_bacon.png", IsMain = true, SortOrder = 1 }
                        }
                    }
                };
                await productContext.Consumables.AddRangeAsync(consumables);
                await productContext.SaveChangesAsync();
            }

            // 11. Корзины (пустые для пользователей)
            if (!orderContext.Cart.Any())
            {
                var users = userContext.Users.ToList();
                var carts = new List<CartData>();

                foreach (var user in users)
                {
                    carts.Add(new CartData
                    {
                        UserId = user.Id
                    });
                }

                await orderContext.Cart.AddRangeAsync(carts);
                await orderContext.SaveChangesAsync();
            }

            // 12. Тестовый заказ
            if (!orderContext.Orders.Any())
            {
                var testUser = userContext.Users.FirstOrDefault(u => u.NickName == "testuser");
                if (testUser != null)
                {
                    var products = productContext.Products.Take(2).ToList();

                    var order = new OrderData
                    {
                        UserId = testUser.Id,
                        OrderNumber = $"ORD-{DateTime.UtcNow:yyyyMMdd}-0001",
                        Status = OrderStatus.Pending,
                        TotalAmount = 0,
                        DeliveryAddress = "г. Москва, ул. Тестовая, д. 1",
                        Comment = "Тестовый заказ",
                        Items = new List<OrderItemData>()
                    };

                    decimal total = 0;
                    foreach (var product in products)
                    {
                        var orderItem = new OrderItemData
                        {
                            ProductId = product.Id,
                            Quantity = 1,
                            Price = product.Price
                        };
                        order.Items.Add(orderItem);
                        total += product.Price;
                    }

                    order.TotalAmount = total;
                    await orderContext.Orders.AddAsync(order);
                    await orderContext.SaveChangesAsync();
                }
            }
        }
    }
}
