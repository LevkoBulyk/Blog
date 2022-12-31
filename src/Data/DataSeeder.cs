using Blog.Data.Enum;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Blog.Data
{
    public class DataSeeder
    {
        private static readonly List<Article> articles = new List<Article>()
        {
            new Article()
            {
                Id = 1,
                Title = "Test",
                Abstract = "This is the abstract to the test article",
                Text = "Here there will be the text of the article with images and videos",
                LastEdition = DateTime.Now.AddDays(-1),
                ImageUrl = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",

            },
            new Article()
            {
                Id = 2,
                Title = "Test 2",
                Abstract = "As can be seen from Fig. 43a, different parts of the same sample show different luminescence, and the difference appears mainly in the 540 – 542 nm region, which is not the region of the phonon replicas. The sample is rather not homogenous, and it may have an inhomogeneous concentration of the defects and even may have inclusions of other phases. As well, the already mentioned domain structure may play a significant role in these modifications. These factors lead to the increase of the luminescence above 540 nm.",
                Text = "",
                LastEdition = DateTime.Now.AddMonths(-1)
            },
            new Article()
            {
                Id = 3,
                Title = "Test article with long title",
                Abstract = "This is the abstract to the test article with long title article",
                Text = "<h1 style=\"text-align: center;\">What is Rich Text Editor?</h1><p><a href=\"https://richtexteditor.com\">Rich Text Editor</a> is a full-featured Javascript WYSIWYG HTML editor. It enables content contributors easily create and publish HTML anywhere: on the desktop and on mobile.</p><p style=\"text-align: center;\"><img src=\"/images/editor-image.png\" alt=\"Editor image\"></p><h4>Key features:</h4><ul><li>Built-in image handling &amp; storage</li><li>File drag &amp; drop</li><li>Table Insert</li><li>Provides a fully customizable toolbar</li><li>Paste from Word, Excel and Google Docs</li><li>Mobile Device Support</li></ul>",
                LastEdition = DateTime.Now
            }
        };

        private static readonly List<AppUser> appUsers = new List<AppUser>()
        {
            new AppUser()
            {
                Name = "Olenka"
            },
            new AppUser()
            {
                Name = "Test"
            }
        };

        public static void SeedDataToDB(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                
                if (!context.Articles.Any())
                {
                    context.Articles.AddRange(articles);
                }

                if (!context.AppUsers.Any())
                {
                    context.Users.AddRange(appUsers);
                }

                context.SaveChanges();
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "levivanbulyk@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        Name = "Olenka",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "123qwe");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "bulyk@ifpan.edu.pl";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        Name = "Lev",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "123qwe");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
