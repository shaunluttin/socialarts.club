namespace socialarts.club.Data
{
    public abstract class BibliographyEntry
    {
        public int Id { get; set; }

        public string Title { get; set; }

        // optional chapter/section
        public string Section { get; set; }

        // TODO (maybe): Break Author into a List<string>
        public string Authors { get; set; }

        public int Year { get; set; }

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