using Blog.Models;

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

                context.SaveChanges();
            }
        }
    }
}
