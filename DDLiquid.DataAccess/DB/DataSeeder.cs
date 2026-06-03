using DDLiquid.Domain.Entities.BaseProduct;
using DDLiquid.Domain.Entities.BaseProduct.Brand;
using DDLiquid.Domain.Entities.Consumable;
using DDLiquid.Domain.Entities.Liquid;
using DDLiquid.Domain.Entities.Product;
using DDLiquid.Domain.Entities.Vape;
using DDLiquid.Domain.Enums;
using DDLiquid.Domain.Entities.User;
using DDLiquid.Domain.Entities.Order;
using DDLiquid.Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;

namespace DDLiquid.DataAccess.DB
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(ProductDbContext productContext, UserDbContext userContext, OrderDbContext orderContext)
        {
            await productContext.Database.MigrateAsync();
            await userContext.Database.MigrateAsync();
            await orderContext.Database.MigrateAsync();

            // Очистка существующих данных (для разработки)
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"LiquidFlavors\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"ProductTags\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"ProductImages\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"Liquids\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"Vapes\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"Consumables\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"Products\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"Flavors\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"Tags\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"Categories\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"Brands\"");
            await productContext.Database.ExecuteSqlRawAsync("DELETE FROM \"Countries\"");
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
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                        RoleId = adminRole.Id
                    },
                      new UserData
                    {
                        NickName = "admin1",
                        Email = "admin1@example.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                        RoleId = adminRole.Id
                    },
                    new UserData
                    {
                        NickName = "testuser",
                        Email = "user@test.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("User123!"),
                        RoleId = userRole.Id
                    }
                };
                await userContext.Users.AddRangeAsync(users);
                await userContext.SaveChangesAsync();
            }
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
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Jija.png", IsMain = true, SortOrder = 1 }
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
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Jija.png", IsMain = true, SortOrder = 1 }
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
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Jija.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new LiquidData
                    {
                        Name = "Watermelon Ice",
                        Description = "Освежающий арбуз с ледяным послевкусием",
                        Price = 11.99m,
                        StockQuantity = 45,
                        Volume = 30,
                        Nicotine = 50,
                        IceLevel = 5,
                        BrandId = elfbar.Id,
                        CategoryId = catLiquid.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Jija.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new LiquidData
                    {
                        Name = "Strawberry Lemonade",
                        Description = "Клубничный лимонад — идеальное сочетание",
                        Price = 13.49m,
                        StockQuantity = 30,
                        Volume = 60,
                        Nicotine = 0,
                        IceLevel = 0,
                        BrandId = nasty.Id,
                        CategoryId = catLiquid.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Jija.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new LiquidData
                    {
                        Name = "Grape Blast",
                        Description = "Насыщенный виноградный вкус",
                        Price = 8.99m,
                        StockQuantity = 40,
                        Volume = 100,
                        Nicotine = 3,
                        IceLevel = 1,
                        BrandId = vampire.Id,
                        CategoryId = catLiquid.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Jija.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new LiquidData
                    {
                        Name = "Peach Ice Tea",
                        Description = "Персиковый чай со льдом",
                        Price = 12.49m,
                        StockQuantity = 25,
                        Volume = 60,
                        Nicotine = 12,
                        IceLevel = 2,
                        BrandId = nasty.Id,
                        CategoryId = catLiquid.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Jija.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new LiquidData
                    {
                        Name = "Triple Berry",
                        Description = "Микс из трех ягод — черника, клубника и арбуз",
                        Price = 14.99m,
                        StockQuantity = 15,
                        Volume = 30,
                        Nicotine = 20,
                        IceLevel = 0,
                        BrandId = elfbar.Id,
                        CategoryId = catLiquid.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Jija.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new LiquidData
                    {
                        Name = "Mango Tango",
                        Description = "Тропическое манго с легкой кислинкой",
                        Price = 11.49m,
                        StockQuantity = 55,
                        Volume = 100,
                        Nicotine = 6,
                        IceLevel = 1,
                        BrandId = vampire.Id,
                        CategoryId = catLiquid.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Jija.png", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new LiquidData
                    {
                        Name = "Blueberry Lemon",
                        Description = "Черника с лимоном — свежий и яркий вкус",
                        Price = 10.49m,
                        StockQuantity = 38,
                        Volume = 60,
                        Nicotine = 3,
                        IceLevel = 0,
                        BrandId = nasty.Id,
                        CategoryId = catLiquid.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Jija.png", IsMain = true, SortOrder = 1 }
                        }
                    }
                };
                await productContext.Liquids.AddRangeAsync(liquids);
                await productContext.SaveChangesAsync();

                // Добавляем связи many-to-many после сохранения продуктов
                var fMango = await productContext.Flavors.FirstAsync(f => f.Name == "Mango");
                var fBlueberry = await productContext.Flavors.FirstAsync(f => f.Name == "Blueberry");
                var fIce = await productContext.Flavors.FirstAsync(f => f.Name == "Ice");
                var fStrawberry = await productContext.Flavors.FirstAsync(f => f.Name == "Strawberry");
                var fWatermelon = await productContext.Flavors.FirstAsync(f => f.Name == "Watermelon");
                var fPeach = await productContext.Flavors.FirstAsync(f => f.Name == "Peach");
                var fGrape = await productContext.Flavors.FirstAsync(f => f.Name == "Grape");
                var fLemon = await productContext.Flavors.FirstAsync(f => f.Name == "Lemon");

                var tagHit = await productContext.Tags.FirstAsync(t => t.Name == "Хит продаж");
                var tagSalt = await productContext.Tags.FirstAsync(t => t.Name == "Солевой");
                var tagNew = await productContext.Tags.FirstAsync(t => t.Name == "Новинка");

                var savedLiquids = await productContext.Liquids.Include(l => l.Flavors).Include(l => l.Tags).ToListAsync();

                savedLiquids[0].Flavors.Add(fBlueberry);
                savedLiquids[0].Flavors.Add(fIce);
                savedLiquids[0].Tags.Add(tagHit);
                savedLiquids[0].Tags.Add(tagSalt);

                savedLiquids[1].Flavors.Add(fMango);
                savedLiquids[1].Flavors.Add(fPeach);
                savedLiquids[1].Tags.Add(tagNew);

                savedLiquids[2].Flavors.Add(fStrawberry);
                savedLiquids[2].Flavors.Add(fWatermelon);
                savedLiquids[2].Tags.Add(tagHit);

                savedLiquids[3].Flavors.Add(fWatermelon);
                savedLiquids[3].Flavors.Add(fIce);
                savedLiquids[3].Tags.Add(tagSalt);
                savedLiquids[3].Tags.Add(tagNew);

                savedLiquids[4].Flavors.Add(fStrawberry);
                savedLiquids[4].Flavors.Add(fLemon);
                savedLiquids[4].Tags.Add(tagNew);

                savedLiquids[5].Flavors.Add(fGrape);
                savedLiquids[5].Tags.Add(tagHit);

                savedLiquids[6].Flavors.Add(fPeach);
                savedLiquids[6].Flavors.Add(fIce);
                savedLiquids[6].Tags.Add(tagNew);

                savedLiquids[7].Flavors.Add(fBlueberry);
                savedLiquids[7].Flavors.Add(fStrawberry);
                savedLiquids[7].Flavors.Add(fWatermelon);
                savedLiquids[7].Tags.Add(tagHit);
                savedLiquids[7].Tags.Add(tagSalt);

                savedLiquids[8].Flavors.Add(fMango);
                savedLiquids[8].Flavors.Add(fLemon);
                savedLiquids[8].Tags.Add(tagNew);

                savedLiquids[9].Flavors.Add(fBlueberry);
                savedLiquids[9].Flavors.Add(fLemon);
                savedLiquids[9].Tags.Add(tagNew);

                await productContext.SaveChangesAsync();
            }

            // 9. Вейпы
            if (!await productContext.Vapes.AnyAsync())
            {
                var voopoo = await productContext.Brands.FirstAsync(b => b.Name == "Voopoo");
                var geekvape = await productContext.Brands.FirstAsync(b => b.Name == "Geekvape");
                var elfbar = await productContext.Brands.FirstAsync(b => b.Name == "Elfbar");
                var catVape = await productContext.Categories.FirstAsync(c => c.Name == "Девайсы");

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
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Pod.jpg", IsMain = true, SortOrder = 1 }
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
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Pod.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new VapeData
                    {
                        Name = "Drag X Plus",
                        Description = "Мощный под-мод с регулировкой до 100W",
                        Price = 54.99m,
                        StockQuantity = 20,
                        BatteryCapacity = 2500,
                        MaxPower = 100,
                        Color = "Blue",
                        TankCapacity = 4.5m,
                        CoilResistance = 0.2m,
                        BrandId = voopoo.Id,
                        CategoryId = catVape.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Pod.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new VapeData
                    {
                        Name = "Aegis Mini",
                        Description = "Компактный защищенный мод для новичков",
                        Price = 44.99m,
                        StockQuantity = 25,
                        BatteryCapacity = 2200,
                        MaxPower = 80,
                        Color = "Green",
                        TankCapacity = 3.5m,
                        CoilResistance = 0.4m,
                        BrandId = geekvape.Id,
                        CategoryId = catVape.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Pod.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new VapeData
                    {
                        Name = "Elfbar BC5000",
                        Description = "Популярная одноразка на 5000 затяжек",
                        Price = 19.99m,
                        StockQuantity = 100,
                        BatteryCapacity = 650,
                        MaxPower = 40,
                        Color = "Red",
                        TankCapacity = 2.0m,
                        CoilResistance = 1.2m,
                        BrandId = elfbar.Id,
                        CategoryId = catVape.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Pod.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new VapeData
                    {
                        Name = "Voopoo Vinci 3",
                        Description = "Стильный под-мод с OLED дисплеем",
                        Price = 59.99m,
                        StockQuantity = 18,
                        BatteryCapacity = 1800,
                        MaxPower = 50,
                        Color = "Black",
                        TankCapacity = 4.0m,
                        CoilResistance = 0.3m,
                        BrandId = voopoo.Id,
                        CategoryId = catVape.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Pod.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new VapeData
                    {
                        Name = "Geekvape Z200",
                        Description = "Двухаккумуляторный мод с мощностью 200W",
                        Price = 89.99m,
                        StockQuantity = 8,
                        BatteryCapacity = 5000,
                        MaxPower = 200,
                        Color = "Silver",
                        TankCapacity = 6.0m,
                        CoilResistance = 0.15m,
                        BrandId = geekvape.Id,
                        CategoryId = catVape.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Pod.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new VapeData
                    {
                        Name = "Elfbar 600",
                        Description = "Компактная одноразка на 600 затяжек",
                        Price = 9.99m,
                        StockQuantity = 150,
                        BatteryCapacity = 550,
                        MaxPower = 30,
                        Color = "Pink",
                        TankCapacity = 2.0m,
                        CoilResistance = 1.6m,
                        BrandId = elfbar.Id,
                        CategoryId = catVape.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Pod.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new VapeData
                    {
                        Name = "Voopoo Argus Pro",
                        Description = "Универсальный мод с кожаной отделкой",
                        Price = 69.99m,
                        StockQuantity = 12,
                        BatteryCapacity = 3000,
                        MaxPower = 80,
                        Color = "Brown",
                        TankCapacity = 4.5m,
                        CoilResistance = 0.25m,
                        BrandId = voopoo.Id,
                        CategoryId = catVape.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Pod.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new VapeData
                    {
                        Name = "Geekvape Aegis Solo 2",
                        Description = "Однобатарейный защищенный мод",
                        Price = 49.99m,
                        StockQuantity = 22,
                        BatteryCapacity = 2000,
                        MaxPower = 100,
                        Color = "Blue",
                        TankCapacity = 5.0m,
                        CoilResistance = 0.2m,
                        BrandId = geekvape.Id,
                        CategoryId = catVape.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Pod.jpg", IsMain = true, SortOrder = 1 }
                        }
                    }
                };
                await productContext.Vapes.AddRangeAsync(vapes);
                await productContext.SaveChangesAsync();

                // Добавляем Tags после сохранения
                var tagNew = await productContext.Tags.FirstAsync(t => t.Name == "Новинка");
                var tagHit = await productContext.Tags.FirstAsync(t => t.Name == "Хит продаж");
                var tagDiscount = await productContext.Tags.FirstAsync(t => t.Name == "Скидка");

                var savedVapes = await productContext.Vapes.Include(v => v.Tags).ToListAsync();

                savedVapes[0].Tags.Add(tagHit);
                savedVapes[1].Tags.Add(tagNew);
                savedVapes[2].Tags.Add(tagHit);
                savedVapes[3].Tags.Add(tagNew);
                savedVapes[4].Tags.Add(tagHit);
                savedVapes[5].Tags.Add(tagNew);
                savedVapes[6].Tags.Add(tagNew);
                savedVapes[6].Tags.Add(tagHit);
                savedVapes[7].Tags.Add(tagDiscount);
                savedVapes[8].Tags.Add(tagHit);
                savedVapes[9].Tags.Add(tagNew);

                await productContext.SaveChangesAsync();
            }

            // 10. Расходники
            if (!await productContext.Consumables.AnyAsync())
            {
                var geekvape = await productContext.Brands.FirstAsync(b => b.Name == "Geekvape");
                var voopoo = await productContext.Brands.FirstAsync(b => b.Name == "Voopoo");
                var elfbar = await productContext.Brands.FirstAsync(b => b.Name == "Elfbar");
                var catCons = await productContext.Categories.FirstAsync(c => c.Name == "Расходники");

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
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Automizer.jpg", IsMain = true, SortOrder = 1 }
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
                            new ProductImageData { Url = "/Automizer.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new ConsumableData
                    {
                        Name = "Coil Voopoo PnP 0.15",
                        Description = "Испаритель 0.15 Ом для Drag серии",
                        Price = 5.49m,
                        StockQuantity = 80,
                        BrandId = voopoo.Id,
                        CategoryId = catCons.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Automizer.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new ConsumableData
                    {
                        Name = "Battery 18650 3000mAh",
                        Description = "Аккумулятор 18650 для модов",
                        Price = 12.99m,
                        StockQuantity = 50,
                        BrandId = geekvape.Id,
                        CategoryId = catCons.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Automizer.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new ConsumableData
                    {
                        Name = "Battery 21700 4000mAh",
                        Description = "Мощный аккумулятор 21700",
                        Price = 15.99m,
                        StockQuantity = 40,
                        BrandId = geekvape.Id,
                        CategoryId = catCons.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Automizer.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new ConsumableData
                    {
                        Name = "USB-C Charger 2A",
                        Description = "Быстрое зарядное устройство USB-C",
                        Price = 9.99m,
                        StockQuantity = 70,
                        BrandId = voopoo.Id,
                        CategoryId = catCons.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Automizer.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new ConsumableData
                    {
                        Name = "Drip Tip 810",
                        Description = "Широкий дрип-тип из нержавейки",
                        Price = 3.99m,
                        StockQuantity = 120,
                        BrandId = geekvape.Id,
                        CategoryId = catCons.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Automizer.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new ConsumableData
                    {
                        Name = "Coil Geekvape Z 0.4",
                        Description = "Испаритель 0.4 Ом для MTL затяжки",
                        Price = 4.49m,
                        StockQuantity = 90,
                        BrandId = geekvape.Id,
                        CategoryId = catCons.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Automizer.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new ConsumableData
                    {
                        Name = "Replacement Glass 5ml",
                        Description = "Запасное стекло для бака 5мл",
                        Price = 2.99m,
                        StockQuantity = 150,
                        BrandId = voopoo.Id,
                        CategoryId = catCons.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Automizer.jpg", IsMain = true, SortOrder = 1 }
                        }
                    },
                    new ConsumableData
                    {
                        Name = "Coil Voopoo PnP 0.3",
                        Description = "Универсальный испаритель 0.3 Ом",
                        Price = 5.99m,
                        StockQuantity = 75,
                        BrandId = voopoo.Id,
                        CategoryId = catCons.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "/Automizer.jpg", IsMain = true, SortOrder = 1 }
                        }
                    }
                };
                await productContext.Consumables.AddRangeAsync(consumables);
                await productContext.SaveChangesAsync();

                // Добавляем Tags после сохранения
                var tagNew = await productContext.Tags.FirstAsync(t => t.Name == "Новинка");
                var tagHit = await productContext.Tags.FirstAsync(t => t.Name == "Хит продаж");

                var savedConsumables = await productContext.Consumables.Include(c => c.Tags).ToListAsync();

                savedConsumables[0].Tags.Add(tagNew);
                savedConsumables[2].Tags.Add(tagHit);
                savedConsumables[3].Tags.Add(tagHit);
                savedConsumables[4].Tags.Add(tagNew);
                savedConsumables[7].Tags.Add(tagNew);
                savedConsumables[9].Tags.Add(tagHit);

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

