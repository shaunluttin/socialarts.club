using System;
using System.Linq;
using System.Threading.Tasks;
using OpenIddict.Abstractions;
using OpenIddict.Core;
using OpenIddict.EntityFrameworkCore.Models;

namespace socialarts.club.Data
{
    // see https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-2.1&tabs=visual-studio#add-code-to-initialize-the-db-with-test-data
    public static class DbInitializer
    {
        public static async void Initialize(ApplicationDbContext context, OpenIddictApplicationManager<OpenIddictApplication> manager)
        {
            context.Database.EnsureCreated();

            await AddBibliographEntries(context);
            await AddClientApplications(context, manager);
        }

        private static async Task AddClientApplications(ApplicationDbContext context, OpenIddictApplicationManager<OpenIddictApplication> manager)
        {
            const string clientId = "socialarts.club";

            var app = await manager.FindByClientIdAsync(clientId);
            if (app != null)
            {
                await manager.DeleteAsync(app);
            }

            var descriptor = new OpenIddictApplicationDescriptor
            {
                ClientId = clientId,
                DisplayName = clientId,
                // TODO: Read this from configuration.
                RedirectUris = {
                    new Uri("https://localhost:5001/MyProgressJournal"),
                    new Uri("https://socialarts.club/MyProgressJournal")
                },
                Permissions =
                    {
                        OpenIddictConstants.Permissions.Endpoints.Authorization,
                        OpenIddictConstants.Permissions.GrantTypes.Implicit,
                        OpenIddictConstants.Permissions.Scopes.OpenId,
                    }
            };

            await manager.CreateAsync(descriptor);
        }

        // TODO (nice-to-have) consider de-duplicating the duplicate publisher data.
        private static async Task AddBibliographEntries(ApplicationDbContext context)
        {
            var entries = new BibliographyEntry[] {
                new BibliographyBook {
                    Title = "Your Depression Map",
                    Authors = "Paterson, R. J.",
                    Year = "2002",
                    Publisher = "Oakland, CA: New Harbinger",
                    Slug = "paterson-2002"
                },
                new BibliographyBook {
                    Title = "Doing it with style",
                    Authors = "Crisp, Q., & Carroll, D.",
                    Year = "1981",
                    Publisher = "New York: Watts",
                    Slug = "crisp-1981"
                },
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

            await context.SaveChangesAsync();
        }
    }
}
