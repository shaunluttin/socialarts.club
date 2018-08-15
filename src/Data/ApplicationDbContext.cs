using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace socialarts.club.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BibliographyEntry> BibliographyEntry { get; set; }

        public DbSet<BibliographyBook> BibliographyBook { get; set; }

        public DbSet<BibliographyWebDocument> BibliographyWebDocument { get; set; }

        public DbSet<ToolsDocument> ToolsDocument { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // SQLite does not support the AlterColumnOperation. :-(
        }
    }
}
