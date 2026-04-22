using D_DStore.Domain.Entities.BaseProduct;
using D_DStore.Domain.Entities.BaseProduct.Brand;
using D_DStore.Domain.Entities.Consumable;
using D_DStore.Domain.Entities.Liquid;
using D_DStore.Domain.Entities.Product;
using D_DStore.Domain.Entities.Vape;
using D_DStore.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace D_DStore.DataAccess.DB
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            await context.Database.MigrateAsync();
            if (!await context.Countries.AnyAsync())
            {
                context.Countries.AddRange(
                    new CountryData { Name = "United States", Code = "US" },
                    new CountryData { Name = "United Kingdom", Code = "UK" },
                    new CountryData { Name = "China", Code = "CN" },
                    new CountryData { Name = "France", Code = "FR" }
                );
                await context.SaveChangesAsync();
            }
            if (!await context.Brands.AnyAsync())
            {
                var us = await context.Countries.FirstAsync(c => c.Code == "US");
                var uk = await context.Countries.FirstAsync(c => c.Code == "UK");
                var cn = await context.Countries.FirstAsync(c => c.Code == "CN");

                context.Brands.AddRange(
                    new BrandData { Name = "Elfbar", Description = "Популярный китайский бренд одноразок и жидкостей", CountryId = cn.Id },
                    new BrandData { Name = "Nasty Juice", Description = "Малайзийский бренд премиум жидкостей", CountryId = us.Id },
                    new BrandData { Name = "Voopoo", Description = "Китайский производитель девайсов", CountryId = cn.Id },
                    new BrandData { Name = "Geekvape", Description = "Защищённые моды и атомайзеры", CountryId = cn.Id },
                    new BrandData { Name = "Vampire Vape", Description = "Британский бренд классических жидкостей", CountryId = uk.Id }
                );
                await context.SaveChangesAsync();
            }
            if (!await context.Categories.AnyAsync())
            {
                context.Categories.AddRange(
                    new ProductCategory { Name = "Жидкости", Description = "Жидкости для вейпа", IconUrl = "icons/liquid.png" },
                    new ProductCategory { Name = "Девайсы", Description = "Вейпы и моды", IconUrl = "icons/vape.png" },
                    new ProductCategory { Name = "Расходники", Description = "Испарители, хлопок и т.д.", IconUrl = "icons/consumable.png" }
                );
                await context.SaveChangesAsync();
            }
            if (!await context.Tags.AnyAsync())
            {
                context.Tags.AddRange(
                    new ProductTag { Name = "Новинка" },
                    new ProductTag { Name = "Хит продаж" },
                    new ProductTag { Name = "Солевой" },
                    new ProductTag { Name = "На органике" },
                    new ProductTag { Name = "Скидка" }
                );
                await context.SaveChangesAsync();
            }
            if (!await context.Flavors.AnyAsync())
            {
                context.Flavors.AddRange(
                    new FlavorData { Name = "Mango" },
                    new FlavorData { Name = "Blueberry" },
                    new FlavorData { Name = "Ice" },
                    new FlavorData { Name = "Strawberry" },
                    new FlavorData { Name = "Watermelon" },
                    new FlavorData { Name = "Peach" },
                    new FlavorData { Name = "Grape" },
                    new FlavorData { Name = "Lemon" }
                );
                await context.SaveChangesAsync();
            }
            if (!await context.Liquids.AnyAsync())
            {
                var elfbar = await context.Brands.FirstAsync(b => b.Name == "Elfbar");
                var nasty = await context.Brands.FirstAsync(b => b.Name == "Nasty Juice");
                var vampire = await context.Brands.FirstAsync(b => b.Name == "Vampire Vape");

                var catLiquid = await context.Categories.FirstAsync(c => c.Name == "Жидкости");

                var fMango = await context.Flavors.FirstAsync(f => f.Name == "Mango");
                var fBlueberry = await context.Flavors.FirstAsync(f => f.Name == "Blueberry");
                var fIce = await context.Flavors.FirstAsync(f => f.Name == "Ice");
                var fStrawberry = await context.Flavors.FirstAsync(f => f.Name == "Strawberry");
                var fWatermelon = await context.Flavors.FirstAsync(f => f.Name == "Watermelon");

                var tagHit = await context.Tags.FirstAsync(t => t.Name == "Хит продаж");
                var tagSalt = await context.Tags.FirstAsync(t => t.Name == "Солевой");
                var tagNew = await context.Tags.FirstAsync(t => t.Name == "Новинка");

                context.Liquids.AddRange(
                    new LiquidData
                    {
                        Name = "Blueberry Ice",
                        Description = "Сочная черника с холодком",
                        Price = 12.99m,
                        StockQuantity = 50,
                        Volume = 30,
                        Nicotine = 20,
                        IceLevel = 3,
                        Status = ProductStatus.Available,
                        Type = ProductType.Liquid,
                        BrandId = elfbar.Id,
                        CategoryId = catLiquid.Id,
                        Flavors = new List<FlavorData> { fBlueberry, fIce },
                        Tags = new List<ProductTag> { tagHit, tagSalt },
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
                        Status = ProductStatus.Available,
                        Type = ProductType.Liquid,
                        BrandId = nasty.Id,
                        CategoryId = catLiquid.Id,
                        Flavors = new List<FlavorData> { fMango },
                        Tags = new List<ProductTag> { tagNew },
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
                        Status = ProductStatus.Available,
                        Type = ProductType.Liquid,
                        BrandId = vampire.Id,
                        CategoryId = catLiquid.Id,
                        Flavors = new List<FlavorData> { fStrawberry, fWatermelon },
                        Tags = new List<ProductTag> { tagHit },
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "images/heisenberg.png", IsMain = true, SortOrder = 1 }
                        }
                    }
                );
                await context.SaveChangesAsync();
            }

            if (!await context.Vapes.AnyAsync())
            {
                var voopoo = await context.Brands.FirstAsync(b => b.Name == "Voopoo");
                var geekvape = await context.Brands.FirstAsync(b => b.Name == "Geekvape");
                var catVape = await context.Categories.FirstAsync(c => c.Name == "Девайсы");
                var tagNew = await context.Tags.FirstAsync(t => t.Name == "Новинка");
                var tagHit = await context.Tags.FirstAsync(t => t.Name == "Хит продаж");

                context.Vapes.AddRange(
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
                        Status = ProductStatus.Available,
                        Type = ProductType.Vape,
                        BrandId = voopoo.Id,
                        CategoryId = catVape.Id,
                        Tags = new List<ProductTag> { tagHit },
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
                        Status = ProductStatus.Available,
                        Type = ProductType.Vape,
                        BrandId = geekvape.Id,
                        CategoryId = catVape.Id,
                        Tags = new List<ProductTag> { tagNew },
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "images/aegis2.png", IsMain = true, SortOrder = 1 }
                        }
                    }
                );
                await context.SaveChangesAsync();
            }

            if (!await context.Consumables.AnyAsync())
            {
                var geekvape = await context.Brands.FirstAsync(b => b.Name == "Geekvape");
                var catCons = await context.Categories.FirstAsync(c => c.Name == "Расходники");
                var tagNew = await context.Tags.FirstAsync(t => t.Name == "Новинка");

                context.Consumables.AddRange(
                    new ConsumableData
                    {
                        Name = "Coil Geekvape Z 0.2",
                        Description = "Испаритель 0.2 Ом для серии Aegis",
                        Price = 4.99m,
                        StockQuantity = 100,
                        Status = ProductStatus.Available,
                        Type = ProductType.Consumable,
                        BrandId = geekvape.Id,
                        CategoryId = catCons.Id,
                        Tags = new List<ProductTag> { tagNew },
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
                        Status = ProductStatus.Available,
                        Type = ProductType.Consumable,
                        BrandId = geekvape.Id,
                        CategoryId = catCons.Id,
                        Images = new List<ProductImageData>
                        {
                            new ProductImageData { Url = "images/cotton_bacon.png", IsMain = true, SortOrder = 1 }
                        }
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}