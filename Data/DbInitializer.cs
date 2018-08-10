using System.Linq;

namespace socialarts.club.Data
{
    // see https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-2.1&tabs=visual-studio#add-code-to-initialize-the-db-with-test-data
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            AddBibliographEntries(context);
        }

        public static void AddBibliographEntries(ApplicationDbContext context) {
            if(context.BibliographyEntry.Any())  return;

            var entries = new BibliographyEntry[] {
                new BibliographyWebDocument {
                    Title = "Antidepressant Skills at Work: Dealing with mood problems in the workplace",
                    Authors = "Bilsker, D., Gilbert, M., & Samra, J.",
                    Year = "2009", 
                    RetrievedFrom = "http://www.comh.ca/antidepressant-skills/work/workbook/pages/worksheets-01.cfm",
                    Slug = "bilsker-2009"
                },
                new BibliographyBook {
                    Title = "The assertiveness workbook: How to express your ideas and stand up for yourself at work and in relationships",
                    Authors = "Paterson, R. J.",
                    Year = "2000", 
                    Publisher = "Oakland, CA: New Harbinger Publications",
                    Slug = "paterson-2000"
                },
                new BibliographyBook {
                    Title = "Your Perfect Right",
                    Authors = "Alberti, R. E., & Emmons, M.",
                    Year = "1995", 
                    Publisher = "San Luis Obispo, California: Impact Publishers",
                    Slug = "alberti-1995",
                },
                new BibliographyBook {
                    Title = "The Anger Control Workbook",
                    Authors = "McKay, M. & Rogers, R.",
                    Year = "2000", 
                    Publisher = "Oakland, CA: New Harbinger Publications",
                    Slug = "mckay-2000",
                },
            };

            foreach(var entry in entries) {
                // TODO Why not use AddRange?
                context.BibliographyEntry.Add(entry);
            }

            context.SaveChanges();
        }
    }
}
