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
                LastEdition = DateTime.Now.AddDays(-1)
            },
            new Article()
            {
                Id = 2,
                Title = "Test 2",
                Abstract = "As can be seen from Fig. 43a, different parts of the same sample show different luminescence, and the difference appears mainly in the 540 – 542 nm region, which is not the region of the phonon replicas. The sample is rather not homogenous, and it may have an inhomogeneous concentration of the defects and even may have inclusions of other phases. As well, the already mentioned domain structure may play a significant role in these modifications. These factors lead to the increase of the luminescence above 540 nm.",
                LastEdition = DateTime.Now.AddMonths(-1)
            },
            new Article()
            {
                Id = 3,
                Title = "Test article with long title",
                Abstract = "This is the abstract to the test article with long title article",
                LastEdition = DateTime.Now
            }
        };

        private static readonly List<ArticleMedia> medias = new List<ArticleMedia>()
        {
            new ArticleMedia()
            {
                Id = 1,
                LocationOrder = 1,
                ArticleId = 1,
                Title = "Title of media 1",
                MediaUrl = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
            },
            new ArticleMedia()
            {
                Id = 2,
                LocationOrder = 1,
                ArticleId = 3,
                Title = "Test",
                MediaUrl = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
            },
            new ArticleMedia()
            {
                Id = 3,
                LocationOrder = 3,
                ArticleId = 1,
                MediaUrl = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
            }
        };

        private static readonly List<ArticleText> texts = new List<ArticleText>()
        {
            new ArticleText()
            {
                Id = 1,
                LocationOrder = 2,
                ArticleId = 1,
                Text = "Luminescence spectra of CsPbBr3 measured at liquid helium temperature under 405 nm laser excitation are shown in Fig. 43. Relatively sharp lines at 534 nm and 542 nm are related to the free and Rashba excitons, respectively. In some cases, for example, like it is in Fig. 43, the Raman line seems to be marked not exactly in the maximum of the peak. Due to the overlap of the Rashba exciton with the phonon replicas, defect bands, and possibly bi-excitons, the exact position of the Rashba line is hard to be established exactly. Therefore, the position of the Rashba line is accepted to be 542 nm, as the mean value of many experimental results from this and many other works. The line at 536 nm is the phonon replica of the free exciton. Relatively broad lines around and above 540 nm were assigned to the defect luminescence. Around 542 nm Rashba exciton and defect lines are overlapping, and therefore it is difficult to separate them. Lines origin is assigned following [41], but evidently, some additional lines are present in the luminescence spectra."
            },
            new ArticleText()
            {
                Id = 2,
                LocationOrder = 4,
                ArticleId = 1,
                Text = "Two temperature regions can be found in the intensity dependence on temperature. The First (low temperature) region is formed by more rapid quenching of the integral luminescence. The defect luminescence is completely quenched in this range. It ends around 80 K, and excitonic luminescence continues decreasing more slowly afterward. In Fig. 45, the dependence of the luminescence of the ground sample is shown. No free exciton luminescence can be observed in the spectra of the ground sample, only the broadband with a maximum of around 575 nm is present. In Fig. 45b integral intensities of entire spectra of different samples are compared. The samples are given in the decreasing order of the defect concentrations in them: ground, chopped piece, and a single piece of (471). From the comparison of the spectra, presented in Fig. 43c, a conclusion has been done, that the ground sample should have an extremely high concentration of the defects. As can be seen from Fig. 45b, the defect luminescence is quenched with the same rate, doesn’t matter the defect concentration (at least at the concentration range, which our sample has). At 70 K luminescence of the defects is already negligibly small, and at higher temperatures, only excitonic luminescence is present, which is in agreement with the model of the defects forming an exponential distribution of the levels below the bottom of the conduction band from work [89]."
            },
            new ArticleText()
            {
                Id = 3,
                LocationOrder = 1,
                ArticleId = 2,
                Text = "Test"
            },
            new ArticleText()
            {
                Id = 4,
                LocationOrder = 1,
                ArticleId = 2,
                Text = "The luminescence of the sample with high defect concentration (number d001) was measured as a function of pressure at low temperature. Results are shown in Fig. 46. Results are divided into a few groups. In Fig. 46a defect luminescence is shown at the pressures before amorphization started. From the spectra, we can suppose the existence of shallow (575 nm at ambient pressure) and deep defects (around 650 nm). The intensity of the shallow defect luminesces decreases with the pressure increase up to approximately 2.5 GPa, while the deep defect seems to be unaffected by the pressure. The origin of these defects is not investigated in this work. Pressure region from 2.9 GPa up to 5.13 GPa is shown in Fig. 46b. As can be seen from it, both intensities and positions of shallow and deep defects are almost independent of pressure. Only at the pressures above approximately 4 GPa, deep defect starts shifting towards higher energies, which continues up to 20 GPa, where luminescence is completely quenched (see Fig. 46c). Shallow defect luminescence is quenched around 6 GPa, while the intensity of the deep defect increases, reaches its maximum around 9 GPa, and afterward decreases.\r\nThis behavior is not typical for luminescence under high pressure. With the pressure increase the band gap of most materials increases, which results in the blue-shift of the sample luminescence. In the case of CsPbBr3, high-pressure measurements showed a decrease in the band gap below 1 GPa and an increase of it at higher pressures. The behavior of the excitonic luminescence is the experimental proof of this. But it is completely quenched at pressures above 2 GPa (see details in chapter IV.3.7). Luminescence in Fig. 46 is not typical for CsPbBr3. Due to the high inhomogeneity of that particular sample (with number d001), the assumption can be made, that there are some problems with it, like a high amount of another phase. For example, CsPb2Br5 is known to have CsPbBr3 incorporations [90], which indicates the possibility of simultaneous coexistence of these phases. Nevertheless, defect luminescence shifting should correlate with the band gap movement. If this signal is from highly defected CsPbBr3, and not from some unknown inclusions in this particular sample, then the blue shift of the luminescence (see Fig. 46) suggests CsPbBr3 band gap increase after 2 GPa, and even faster increase after 4 GPa."
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

                if (!context.ArticleMedias.Any())
                {
                    context.ArticleMedias.AddRange(medias);
                }

                if (!context.ArticleTexts.Any())
                {
                    context.ArticleTexts.AddRange(texts);
                }

                context.SaveChanges();
            }
        }
    }
}
