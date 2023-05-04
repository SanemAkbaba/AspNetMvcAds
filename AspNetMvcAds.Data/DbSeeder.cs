using AspNetMvcAds.Data.Data.Entity;
using AspNetMvcAds.Web.Mvc.Data.Entity;

namespace AspNetMvcAds.Data
{
    public class DbSeeder
    {
        public static void Seed()
        {
            using (var context = new AppDbContext())
            {
                if (!context.Users.Any())
                {
                    var user1 = new User()
                    {
                        Name = "Nilüfer Ülgen",
                        Email = "nilufer@webmail.com",
                        Password = "123",
                        Address = "Muğla",
                        Phone = "535555",
                        Roles = "Guest"
                    };
                    context.Users.Add(user1);

                    var user2 = new User()
                    {
                        Name = "Didem Evran",
                        Email = "didem@webmail.com",
                        Password = "456",
                        Address = "Almanya",
                        Phone = "858747",
                        Roles = "Guest"
                    };
                    context.Users.Add(user2);

                    var user3 = new User()
                    {
                        Name = "Sanem Akbaba",
                        Email = "sanem@webmail.com",
                        Password = "789",
                        Address = "İzmir",
                        Phone = "538777",
                        Roles = "Guest"
                    };
                    context.Users.Add(user3);

                    context.SaveChanges();
                }


                if (!context.Settings.Any())
                {
                    var settings = new List<Setting>()
                    {
                        new Setting{ UserId=1, Name="Ayarlar_1", Value="Değer_1"},
                        new Setting{ UserId=2, Name="Ayarlar_2", Value="Değer_2"},
                        new Setting{ UserId=3, Name="Ayarlar_3", Value="Değer_3"}
                    };
                    context.Settings.AddRange(settings);
                    context.SaveChanges();
                }

                if (!context.Categories.Any())
                {
                    var categories = new List<Category>()
                    {
                        new Category{ Name= "Electronics", Logo="fa-laptop"},
                        new Category{ Name= "Restaurants", Logo="fa-apple"},
                        new Category{ Name= "Real Estate", Logo="fa-home"},
                        new Category{ Name= "Shoppings", Logo="fa-shopping-basket"},
                        new Category{ Name= "Jobs", Logo="fa-briefcase"},
                        new Category{ Name= "Vechicles", Logo="fa-car"},
                        new Category{ Name= "Pets", Logo="fa-paw"},
                        new Category{ Name= "Services", Logo="fa-laptop"},
                    };
                    context.Categories.AddRange(categories);
                    context.SaveChanges();

                    var electronicsSubCategories = new List<Category> {
                        new Category { ParentId = categories[0].Id, Name = "Laptops" , Amount = 93},
                        new Category { ParentId = categories[0].Id, Name = "Iphone" , Amount = 233},
                        new Category { ParentId = categories[0].Id, Name = "Microsoft" , Amount = 183},
                        new Category { ParentId = categories[0].Id, Name = "Monitors" , Amount = 343}
                    };
                    context.Categories.AddRange(electronicsSubCategories);

                    var restaurantsSubCategories = new List<Category> {
                        new Category { ParentId = categories[1].Id, Name = "Cafe" , Amount = 393},
                        new Category { ParentId = categories[1].Id, Name = "Fast food" , Amount = 23},
                        new Category { ParentId = categories[1].Id, Name = "Restaurants" , Amount = 13},
                        new Category { ParentId = categories[1].Id, Name = "Food Track" , Amount = 43}
                    };
                    context.Categories.AddRange(restaurantsSubCategories);

                    var reSubCategories = new List<Category> {
                        new Category { ParentId = categories[2].Id, Name = "Farms" , Amount = 93},
                        new Category { ParentId = categories[2].Id, Name = "Gym" , Amount = 23},
                        new Category { ParentId = categories[2].Id, Name = "Hospitals" , Amount = 83},
                        new Category { ParentId = categories[2].Id, Name = "Parolurs" , Amount = 33}
                    };
                    context.Categories.AddRange(reSubCategories);

                    var shoppingsSubCategories = new List<Category> {
                        new Category { ParentId = categories[3].Id, Name = "Mens Wears" , Amount = 53},
                        new Category { ParentId = categories[3].Id, Name = "Accesories" , Amount = 212},
                        new Category { ParentId = categories[3].Id, Name = "Kids Wears" , Amount = 133},
                        new Category { ParentId = categories[3].Id, Name = "It & Software" , Amount = 143}
                    };
                    context.Categories.AddRange(shoppingsSubCategories);

                    var jobsCategories = new List<Category> {
                        new Category { ParentId = categories[4].Id, Name = "It Jobs" , Amount = 93},
                        new Category { ParentId = categories[4].Id, Name = "Cleaning & Washing" , Amount = 233},
                        new Category { ParentId = categories[4].Id, Name = "Management" , Amount = 183},
                        new Category { ParentId = categories[4].Id, Name = "Voluntary Works" , Amount = 343}
                    };
                    context.Categories.AddRange(jobsCategories);

                    var vehiclesSubCategories = new List<Category> {
                        new Category { ParentId = categories[5].Id, Name = "Bus" , Amount = 193},
                        new Category { ParentId = categories[5].Id, Name = "Cars" , Amount = 23},
                        new Category { ParentId = categories[5].Id, Name = "Motobike" , Amount = 33},
                        new Category { ParentId = categories[5].Id, Name = "Rent a car" , Amount = 73}
                    };
                    context.Categories.AddRange(vehiclesSubCategories);

                    var petsSubCategories = new List<Category> {
                        new Category { ParentId = categories[6].Id, Name = "Cats" , Amount = 65},
                        new Category { ParentId = categories[6].Id, Name = "Dogs" , Amount = 23},
                        new Category { ParentId = categories[6].Id, Name = "Birds" , Amount = 133},
                        new Category { ParentId = categories[6].Id, Name = "Others" , Amount = 43}
                    };
                    context.Categories.AddRange(petsSubCategories);

                    var servicesSubCategories = new List<Category> {
                        new Category { ParentId = categories[7].Id, Name = "Cleaning" , Amount = 93},
                        new Category { ParentId = categories[7].Id, Name = "Car Washing" , Amount = 233},
                        new Category { ParentId = categories[7].Id, Name = "Clothing" , Amount = 183},
                        new Category { ParentId = categories[7].Id, Name = "Business" , Amount = 343}
                    };
                    context.Categories.AddRange(servicesSubCategories);

                    context.SaveChanges();
                }

                if (!context.Adverts.Any())
                {
                    var adverts = new List<Advert>()
                    {
                        new Advert { UserId=1, Title="13inch Macbook Air", Description= "", IsTrend = true, CategoryId=1},
                        new Advert { UserId=2, Title="Monitor", Description= "", IsTrend = true, CategoryId=1},
                        new Advert { UserId=2, Title="Food Track", Description= "", IsTrend = true, CategoryId=6},
                        new Advert { UserId=2, Title="Gym", Description= "", IsTrend = true, CategoryId=3},
                    };
                    context.Adverts.AddRange(adverts);
                    context.SaveChanges();
                }

                if (!context.AdvertImages.Any())
                {
                    var advertimages = new List<AdvertImage>()
                    {
                        new AdvertImage { AdvertId=1, ImagePath="product1_macbookair13.jpg", IsCoverImage = true},
                        new AdvertImage { AdvertId=2, ImagePath="product2_monitor.jpg", IsCoverImage = true},
                        new AdvertImage { AdvertId=3, ImagePath="product3_foodtrack.jpg", IsCoverImage = true},
                        new AdvertImage { AdvertId=4, ImagePath="product4_gym.jpg", IsCoverImage = true},
                    };
                    context.AdvertImages.AddRange(advertimages);
                    context.SaveChanges();
                }


                if (!context.AdvertComments.Any())
                {
                    var advertcomments = new List<AdvertComment>()
                    {
                        new AdvertComment { AdvertId = 1, UserId = 2, Comment="Yorum_1", IsActive=true },
                        new AdvertComment { AdvertId = 2, UserId = 1, Comment="Yorum_2", IsActive=true },
                        new AdvertComment { AdvertId = 3, UserId = 3, Comment="Yorum_3", IsActive=true },
                        new AdvertComment { AdvertId = 4, UserId = 3, Comment="Yorum_4", IsActive=true },
                    };
                    context.AdvertComments.AddRange(advertcomments);
                    context.SaveChanges();
                }


            }
        }
    }
}