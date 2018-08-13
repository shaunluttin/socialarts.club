namespace socialarts.club.Data
{
    public abstract class BibliographyEntry
    {
        public int Id { get; set; }

        // TODO (maybe): Break Title into two properties: Title & Subtitle
        public string Title { get; set; }

        // optional chapter/section
        public string Section { get; set; }

        // TODO (maybe): Break Author into a List<string>
        public string Authors { get; set; }

        // SQLite does not support the AlterColumnOperation,
        // so altering this to an <int> requires a table rebuild approach.
        public string Year { get; set; }

        // for anchor tags
        public string Slug { get; set; }
    }

    public class BibliographyWebDocument : BibliographyEntry
    {
        public string RetrievedFrom { get; set; }
    }

    public class BibliographyBook : BibliographyEntry 
    {
        // TODO (maybe): Break Publisher into two properties: Location & Publisher
        public string Publisher { get; set; }
    }
}