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

        public static void AddBibliographEntries(ApplicationDbContext context)
        {
            // TODO (nice-to-have) consider de-duplicating the duplicate publisher data.
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
                    // duplicate publisher
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
                    Title = "The Anger Control Workbook: Simple, innovative techniques for managing anger and developing healthier ways of relating",
                    Authors = "McKay, M. & Rogers, R.",
                    Year = "2000",
                    // duplicate publisher
                    Publisher = "Oakland, CA: New Harbinger Publications",
                    Slug = "mckay-2000",
                },
                new BibliographyBook {
                    Title = "Messages: The Communication Skills Book",
                    Authors = "McKay, M., Davis, M., & Fanning, P.",
                    Year = "2009",
                    // duplicate publisher
                    Publisher = "Oakland, CA: New Harbinger Publications",
                    Slug = "mckay-2009",
                },
            };

            foreach (var entry in entries)
            {
                var existing = context.BibliographyEntry.SingleOrDefault(e => e.Slug == entry.Slug);
                if (existing == null)
                {
                    context.BibliographyEntry.Add(entry);
                }
            }

            context.SaveChanges();
        }
    }
}
